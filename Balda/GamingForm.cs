using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Balda
{
    delegate void formUpdatingDelegate(FieldState f, Rules r);
    delegate void wordAddingDelegate(ListViewItem item);
    delegate void playersUpdatingDelegate(List<Player> players, int currentIndex);
    delegate void gameEndingDelegate();
    delegate void formTimeUpdatingDelegate(TimeSpan time);

    public partial class GamingForm : Form
    {
        //the newest local copy of state from the game server
        FieldState state;
        List<KeyValuePair<int, Player>> tableOfRecords;
        Dictionary<string, int> users;
        Mutex humanMoveMutex;
        Thread playingThread;
        private Move humanMove;
        public Move HumanMove
        {
            get
            {
                if (game.timeIsUp == true)
                {
                    Move timeOutMove = new Move();
                    timeOutMove.Action = ActionType.PassTurn;
                    return timeOutMove; 
                }
                humanMoveMutex.WaitOne();
                if (humanMove == null)
                {
                    humanMoveMutex.ReleaseMutex();
                    return null;
                }
                Move moveCopy = (Move)humanMove.Clone();
                humanMove = null;
                humanMoveMutex.ReleaseMutex();
                return moveCopy;
            }
            private set
            {
                humanMove = value;
            }
        }

        private Game game;
        public Game Game
        {
            set
            {
                game = value;
            }
        }

        public GamingForm(Dictionary<string, int> users)
        {
            humanMoveMutex = new Mutex();
            this.users = users;
            InitializeComponent();
        }

        private void GamingForm_Shown(object sender, EventArgs e)
        {
            // Thread playing = new Thread( new ThreadStart(play));
            //  playing.Start();
            playingThread = new Thread(() => game.play(ref tableOfRecords));
            playingThread.Start();
        }

        public void updateTimer(TimeSpan time)
        {
            if (this.InvokeRequired)
            {
                formTimeUpdatingDelegate fud = new formTimeUpdatingDelegate(updateTimer);
                this.Invoke(fud, new object[] { time });
            }
            else
            {
                labelTimer.Text = time.ToString(@"mm\:ss");
            }
        }

        public void updateForm(FieldState state, Rules rules)
        {

            if (this.InvokeRequired)
            {
                formUpdatingDelegate fud = new formUpdatingDelegate(updateForm);
                this.Invoke(fud, new object[] { state, rules });
            }
            else
            {
                this.state = state;
                fieldDataGridView.RowCount = state.Field.GetLength(0);
                fieldDataGridView.ColumnCount = state.Field.GetLength(1);
                for (int i = 0; i < state.Field.GetLength(0); ++i)
                {
                    fieldDataGridView.Rows[i].Height = fieldDataGridView.Size.Height / state.Field.GetLength(1);
                    for (int j = 0; j < state.Field.GetLength(1); ++j)
                    {
                        fieldDataGridView.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        fieldDataGridView.Rows[i].Cells[j].Value = state.Field[i, j];
                        fieldDataGridView.Rows[i].Cells[j].ReadOnly = true;
                        fieldDataGridView.Rows[i].Cells[j].Selected = false;
                    }
                }
                // ↓ is needed to remove the scroll bar
                fieldDataGridView.Rows[0].Height = fieldDataGridView.Size.Height / state.Field.GetLength(1) - 2;
                int newX = state.NewX;
                int newY = state.NewY;
                textBoxWord.Text = "";
                for (int i = 0; i < state.X.Count(); i++)
                {
                    textBoxWord.Text += fieldDataGridView.Rows[state.Y[i]].Cells[state.X[i]].Value;
                }
                if (newX != -1 && newY != -1)
                {
                    // highlight the new letter
                    fieldDataGridView.Rows[newY].Cells[newX].Style.ForeColor = Color.Red;
                    for (int i = 0; i < state.X.Count(); i++)
                    {
                        fieldDataGridView.Rows[state.Y[i]].Cells[state.X[i]].Style.ForeColor = Color.Green;
                    }
                }
                else
                {
                    // if availableCells[i, j] = true, then the user is permitted to place letters there
                    bool[,] availableCells = rules.findAvailableCells(state);
                    // set all the cells to match this array
                    for (int i = 0; i < state.Field.GetLength(0); ++i)
                    {
                        for (int j = 0; j < state.Field.GetLength(1); ++j)
                        {
                            fieldDataGridView.Rows[i].Cells[j].ReadOnly = !availableCells[i, j];
                            fieldDataGridView.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        private void buttonShowMainForm_Click(object sender, EventArgs e)
        {
            game.secondsTimer.Change(Timeout.Infinite, Timeout.Infinite);
            playingThread.Abort();
            this.Owner.Show();
            Close();
        }

        private void fieldDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIdx = e.RowIndex;
            int colIdx = e.ColumnIndex;
            string newValue = fieldDataGridView.Rows[rowIdx].Cells[colIdx].Value.ToString();
            if (newValue.Length == 1)
            {
                humanMoveMutex.WaitOne();
                this.humanMove = new Move();
                this.humanMove.Action = ActionType.EnterLetter;
                this.humanMove.Letter = newValue[0];
                this.humanMove.X = colIdx;
                this.humanMove.Y = rowIdx;
                humanMoveMutex.ReleaseMutex();
            }
            else
            {
                fieldDataGridView.Rows[rowIdx].Cells[colIdx].Value = "\0";
            }
        }

        private void fieldDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (state.NewX != -1 && state.NewY != -1) //it means that user entered letter
            {
                int rowIdx = e.RowIndex;
                int colIdx = e.ColumnIndex;
                humanMoveMutex.WaitOne();
                this.humanMove = new Move();
                this.humanMove.Action = ActionType.SelectLetter;
                this.humanMove.Letter = ' ';// when it was \0 toString didn't work properly;
                this.humanMove.X = colIdx;
                this.humanMove.Y = rowIdx;
                humanMoveMutex.ReleaseMutex();
            }

        }

        private void buttonEndTurn_Click(object sender, EventArgs e)
        {
            humanMoveMutex.WaitOne();
            this.humanMove = new Move();
            this.humanMove.Action = ActionType.EndTurn;
            this.humanMove.Letter = ' ';// when it was \0 toString didn't work properly;
            humanMoveMutex.ReleaseMutex();
        }

        public void addNewWord(ListViewItem item)
        {

            if (this.InvokeRequired)
            {
                wordAddingDelegate fud = new wordAddingDelegate(addNewWord);
                this.Invoke(fud, new object[] { item });
            }
            else
            {
                listViewEnterWords.Items.Add(item);
            }
        }

        public void updatePlayersScore(List<Player> players, int currentIndex)
        {

            if (this.InvokeRequired)
            {
                playersUpdatingDelegate fud = new playersUpdatingDelegate(updatePlayersScore);
                this.Invoke(fud, new object[] { players, currentIndex });
            }
            else
            {
                listViewPlayers.Items.Clear();
                for (int i = 0; i < players.Count; i++)
                {
                    ListViewItem item = new ListViewItem(players[i].Name + " " + players[i].Score.ToString());
                    item.ForeColor = players[i].PlayerColor;
                    item.Font = new System.Drawing.Font(item.Font, System.Drawing.FontStyle.Regular);
                    if (i == currentIndex)
                    {
                        item.Font = new System.Drawing.Font(item.Font, System.Drawing.FontStyle.Bold);
                    }
                    listViewPlayers.Items.Add(item);
                }
            }
        }

        private void buttonResetTurn_Click(object sender, EventArgs e)
        {
            humanMoveMutex.WaitOne();
            this.humanMove = new Move();
            this.humanMove.Action = ActionType.Reset;
            this.humanMove.Letter = ' ';// when it was \0 toString didn't work properly;
            humanMoveMutex.ReleaseMutex();
        }

        private void buttonPassTurn_Click(object sender, EventArgs e)
        {
            humanMoveMutex.WaitOne();
            this.humanMove = new Move();
            this.humanMove.Action = ActionType.PassTurn;
            this.humanMove.Letter = ' ';// when it was \0 toString didn't work properly;
            humanMoveMutex.ReleaseMutex();
        }

        public void gameEnding()
        {

            if (this.InvokeRequired)
            {
                gameEndingDelegate fud = new gameEndingDelegate(gameEnding);
                this.Invoke(fud, new object[] { });
            }
            else
            {
                string stringOfRecords = "";
                bool isBot = false;
                for (int i = 0; i < tableOfRecords.Count; i++)
                {
                    stringOfRecords += tableOfRecords[i].Key.ToString() + ". " + tableOfRecords[i].Value.Name + Environment.NewLine;
                }
                stringOfRecords.TrimEnd(new char[] { '\n' });
                MessageBox.Show(stringOfRecords, "Турнирная таблица");

                for (int i = 0; i < tableOfRecords.Count; i++)
                {
                    if (tableOfRecords[i].Value.Strategy.GetType() == typeof(ComputerStrategy))
                    {
                        isBot = true;
                        break;
                    }
                }

                if (!isBot)
                {
                    users[tableOfRecords[0].Value.Name] += tableOfRecords.Count  - 1;
                    for (int i = 1; i < tableOfRecords.Count; i++)
                    {
                        users[tableOfRecords[i].Value.Name] -= tableOfRecords.Count - 1;
                    }
                }

                playingThread.Abort();
                this.Owner.Show();
                Close();
            }
        }
    }
}
