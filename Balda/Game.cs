using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;

namespace Balda
{
    /**
        * Represents one letter in a sequence of letters called 'word' in Balda terms
        */
    class FieldTreeNode : ICloneable
    {
        public bool isAdded; // is this letter new, or it existed before
        public bool newLetterUsed; // was the ability to add new word used in this sequence of letters
        public FieldTreeNode parent; // points to the previous word in this sequence
        public int x; // coordinates of this letter
        public int y;
        public int letter; // a letter corresponding to this node. To make it char, add capital russian A to this field
        public int prefixTreeIndex; // index of this node in the prefix tree

        public FieldTreeNode(bool isAdded,
                                bool newLetterUsed,
                                FieldTreeNode parent,
                                int x,
                                int y,
                                int letter,
                                int prefixTreeIndex)
        {
            this.isAdded = isAdded;
            this.newLetterUsed = newLetterUsed;
            this.parent = parent;
            this.x = x;
            this.y = y;
            this.letter = letter;
            this.prefixTreeIndex = prefixTreeIndex;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /**
            * Determines whether this word contains a cell with coordinates (x; y)
            */
        public bool containsCoords(int x, int y)
        {
            FieldTreeNode cur = this;
            do
            {
                if (cur.x == x && cur.y == y)
                {
                    return true;
                }
                cur = cur.parent;
            }
            while (cur != null);
            return false;
        }

        /**
            * Returns a letter that did not exist in a field before or null if such a node is absent
            */
        public FieldTreeNode findNewLetter()
        {
            FieldTreeNode cur = this;
            do
            {
                if (cur.isAdded)
                {
                    return cur;
                }
                cur = cur.parent;
            }
            while (cur != null);
            return null;
        }

        /**
            * Returns the length of this sequence
            */
        public int getLength()
        {
            int len = 0;
            FieldTreeNode cur = this;
            do
            {
                ++len;
                cur = cur.parent;
            }
            while (cur != null);
            return len;
        }

        public override string ToString()
        {
            string result = (char)(letter + 'А') + "";
            if (parent != null)
            {
                result = parent.ToString() + result;
            }
            return result;
        }

        public bool containsDiagonal()
        {
            if (parent != null)
            {
                if (this.x != parent.x && this.y != parent.y)
                {
                    return true;
                }
                else
                {
                    return parent.containsDiagonal();
                }
            }
            else
            {
                return false;
            }
        }
    }

    public class Game
    {
        // the following three fields are taken from computerStrategy
        private const int prefixTreeMaxSize = 19168; // this is the number of tree nodes needed to store all our word base
        private int[,] prefixTree = new int[prefixTreeMaxSize, 32]; // 32 letters in russian alphabet (without Ё)
        private bool[] isWord = new bool[prefixTreeMaxSize];

        public FieldState State { get; private set; }
        public Rules Rules { get; private set; }
        public List<Player> Players { get; private set; }
        private WordBase wordBase;
        private GamingForm gamingForm;
        private int consequtiveTurnPasses;
        public bool timeIsUp = false;
        public TimeSpan time;
        TimerCallback secondsTimerCB;
        public System.Threading.Timer secondsTimer;

        public Game(string startWord, List<Player> players, Rules rules, WordBase wordBase, GamingForm gamingForm)
        {
            State = new FieldState(startWord);
            Rules = rules;
            Players = players;
            this.wordBase = wordBase;
            this.gamingForm = gamingForm;
            consequtiveTurnPasses = 0;
            secondsTimerCB = new TimerCallback(timerTick);
            if (Rules.HasTimeLimit == true)
            {
                secondsTimer = new System.Threading.Timer(secondsTimerCB, null, 1000, 1000);
            }

            // now construct the prefix tree
            for (int i = 0; i < prefixTreeMaxSize; ++i)
            {
                isWord[i] = false;
                for (int j = 0; j < 32; ++j)
                {
                    prefixTree[i, j] = -1;
                }
            }
            int firstUnused = 1;
            string[] lines = System.IO.File.ReadAllLines(@"../../word_rus.txt");
            foreach (string word in lines)
            {
                int currentIndex = 0;
                for (int j = 0; j < word.Length; ++j)
                {
                    if (prefixTree[currentIndex, word[j] - 'А'] == -1)
                    {
                        prefixTree[currentIndex, word[j] - 'А'] = firstUnused;
                        currentIndex = firstUnused;
                        ++firstUnused;
                    }
                    else
                    {
                        currentIndex = prefixTree[currentIndex, word[j] - 'А'];
                    }
                    if (j == word.Length - 1)
                    {
                        isWord[currentIndex] = true;
                    }
                }
            }
        }

        public void play(ref List<KeyValuePair<int, Player>> result)
        {
            bool gameEnded = false;
            while (!gameEnded)
            {
                int i = 0;
                foreach (Player player in Players)
                {
                    if (!Rules.AllowRepeats)
                    {
                        recountWords();
                    }
                    processPlayer(player, i++);
                    gameEnded = winCondition();
                    
                    if (gameEnded)
                    {
                        break;
                    }
                }

            }

            Players.Sort((p1, p2) => p2.Score - p1.Score);
            result = new List<KeyValuePair<int, Player>>();
            result.Add(new KeyValuePair<int, Player>(1, Players[0]));
            for (int i = 1; i < Players.Count; i++)
            {
                if (Players[i].Score == Players[i - 1].Score)
                {

                    result.Add(new KeyValuePair<int, Player>(result.Last().Key, Players[i]));
                }
                else
                {
                    result.Add(new KeyValuePair<int, Player>(i + 1, Players[i]));
                }
            }
            if (Rules.HasTimeLimit == true) 
            {
                secondsTimer.Change(Timeout.Infinite, Timeout.Infinite);
            }
            gamingForm.gameEnding();
        }

        private bool winCondition()
        {
            if (consequtiveTurnPasses == Players.Count * 3)
            {
                return true;
            }

            for (int i = 0; i < State.Field.GetLength(0); i++)
            {
                for (int j = 0; j < State.Field.GetLength(1); j++)
                {
                    if (State.Field[i, j] == '\0')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        void timerTick(object state)
        {
            if (timeIsUp == false) 
            {
                time = time.Subtract(new TimeSpan(0, 0, 1));
                gamingForm.updateTimer(time);
            }            
            System.Diagnostics.Debug.WriteLine(time.ToString());            
            if (time == TimeSpan.Zero)
            {
                timeIsUp = true;
            }
        }

        private void processPlayer(Player player, int currentIndex)
        {
            timeIsUp = false;
            bool correctEndTurn = false;
            Move move = new Move();
            //time = new TimeSpan(0, Rules.TimeLimit, 0);
            time = new TimeSpan(0, Rules.TimeLimit, 0);
            gamingForm.updateTimer(time);
            MessageBox.Show("Ходит игрок " + player.Name);
            gamingForm.updatePlayersScore(Players, currentIndex);
           
            do
            {
                if (timeIsUp == false)
                {
                    gamingForm.updateForm(State, Rules);
                    player.Strategy.move(State, ref move, Rules);
                }
                else
                {
                    move.Action = ActionType.PassTurn;
                    
                }
                switch (move.Action)
                {
                    case ActionType.EnterLetter:
                        {
                            int x = move.X, y = move.Y;
                            int width = State.Field.GetLength(0);
                            if (x < 0 || x >= width || y < 0 || y >= width)
                            {
                                // indices out of range
                                break;
                            }
                            move.Letter = Char.ToUpper(move.Letter);
                            if (!isCapitalRussianLetter(move.Letter))
                            {
                                // incorrect character
                                break;
                            }
                            if (State.NewX != -1 && State.NewY != -1)
                            {
                                // user already entered new letter
                                break;
                            }
                            State.NewX = x;
                            State.NewY = y;
                            State.Field[y, x] = move.Letter;
                        }
                        break;
                    case ActionType.SelectLetter:
                        {
                            int wordLength = State.X.Count;
                            int x = move.X, y = move.Y;
                            bool isCorrect = true;
                            int width = State.Field.GetLength(0);
                            if (x < 0 || x >= width || y < 0 || y >= width)
                            {
                                // indices out of range
                                break;
                            }
                            char nullLetter = '\0';
                            if (State.Field[y, x] == nullLetter)
                            {//user must select only letters;
                                break;
                            }
                            if (wordLength == 0)
                            {
                                State.X.Add(x);
                                State.Y.Add(y);
                                break;
                            }
                            if (!Rules.AllowIntersections)
                            {
                                for (int i = 0; i < wordLength; i++)
                                {
                                    if (State.X[i] == x && State.Y[i] == y)
                                    {
                                        //new coordinate intersects with the word
                                        isCorrect = false;
                                        break;
                                    }
                                }
                                if (!isCorrect) break;
                            }
                            if (Rules.isNeighbours(x, y, State.X[wordLength - 1], State.Y[wordLength - 1]))
                            {
                                State.X.Add(x);
                                State.Y.Add(y);
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    case ActionType.EndTurn:
                        {
                            bool foundLetter = false;
                            string word = "";
                            //check if the word contains the newly enter letter
                            if (State.NewX == -1 && State.NewY == -1)
                            {
                                MessageBox.Show("Введите букву");
                                break;
                            }

                            if (State.X.Count == 0 && State.Y.Count == 0)
                            {
                                MessageBox.Show("Выберите слово");
                                break;
                            }

                            for (int i = 0; i < State.X.Count; i++)
                            {
                                if (State.X[i] == State.NewX && State.Y[i] == State.NewY)
                                {
                                    foundLetter = true;
                                    break;
                                }
                            }

                            if (!foundLetter)
                            {
                                MessageBox.Show("Слово не содержит поставленную букву");
                                resetTurn();
                                break;
                            }

                            for (int i = 0; i < State.X.Count; i++)
                            {
                                int x = State.X[i];
                                int y = State.Y[i];
                                word += State.Field[y, x];
                            }

                            if (!wordBase.Contains(word))
                            {
                                MessageBox.Show(String.Format("База не содержит слова - {0}", word));
                                resetTurn();
                                break;
                            }

                            if (State.ProhibitedWords.Contains(word))
                            {
                                MessageBox.Show("Cлово " + word + " уже было");
                                resetTurn();
                                break;
                            }

                            State.ProhibitedWords.Add(word);

                            player.Score += word.Length;

                            State.NewX = -1;
                            State.NewY = -1;
                            State.X.Clear();
                            State.Y.Clear();

                            ListViewItem item = new ListViewItem(word);
                            item.ForeColor = player.PlayerColor;
                            gamingForm.addNewWord(item);
                            consequtiveTurnPasses = 0;
                            correctEndTurn = true;
                            return;
                        }
                        break;
                    case ActionType.Reset:
                        {
                            resetTurn();
                        }
                        break;
                    case ActionType.PassTurn:
                        {
                            consequtiveTurnPasses++;
                            resetTurn();
                            return;
                        }
                        break;
                }
            }
            while (!((move.Action == ActionType.EndTurn && correctEndTurn == true) || move.Action == ActionType.PassTurn));
            // if the user chose non-existing word, we should ask him for another word instead of exitting
            // the very last turn will not be shown otherwise
            gamingForm.updatePlayersScore(Players, currentIndex);
        }

        private bool isCapitalRussianLetter(Char letter)
        {
            return letter >= 'А' && letter <= 'Я';
        }

        private void resetTurn()
        {
            if (State.NewX != -1 && State.NewY != -1)
            {
                State.Field[State.NewY, State.NewX] = '\0';
            }
            State.NewX = -1;
            State.NewY = -1;
            State.X.Clear();
            State.Y.Clear();
        }

        // adds words that are present on the field to prohibitedWords;
        // used by the last story
        private void recountWords()
        {
            int nonDiagonalCounter = 0;
            // then find the optimal move
            int width = State.Field.GetLength(0);
            int[] dx, dy;
            if (Rules.AllowDiagonal == true)
            {
                dx = new int[] { 1, 0, -1, 0, 1, 1, -1, -1 };
                dy = new int[] { 0, 1, 0, -1, 1, -1, 1, -1 };
            }
            else
            {
                dx = new int[] { 1, 0, -1, 0 };
                dy = new int[] { 0, 1, 0, -1 };
            }
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    Stack<FieldTreeNode> st = new Stack<FieldTreeNode>();
                    if (State.Field[i, j] != '\0')
                    {
                        // there is only one possible start node
                        // if there are words that start with this letter
                        if (prefixTree[0, State.Field[i, j] - 'А'] != -1)
                        {
                            st.Push(new FieldTreeNode(false,
                                                      false,
                                                      null,
                                                      j,
                                                      i,
                                                      State.Field[i, j] - 'А',
                                                      prefixTree[0, State.Field[i, j] - 'А']));
                        }
                    }
                    while (st.Count > 0)
                    {
                        FieldTreeNode cur = st.Pop();
                        int cx = cur.x, cy = cur.y;
                        // add all it's neighbours
                        for (int k = 0; k < dx.Length; ++k)
                        {
                            try
                            {
                                if (!Rules.AllowIntersections)
                                {
                                    if (cur.containsCoords(cx + dx[k], cy + dy[k]))
                                    {
                                        continue;
                                    }
                                }
                                // if the neighbour contains a letter and there is a corresponding prefix
                                if (isCapitalRussianLetter(State.Field[cy + dy[k], cx + dx[k]])
                                    && prefixTree[cur.prefixTreeIndex, State.Field[cy + dy[k], cx + dx[k]] - 'А'] != -1)
                                {
                                    st.Push(new FieldTreeNode(false,
                                                                cur.newLetterUsed,
                                                                cur,
                                                                cx + dx[k],
                                                                cy + dy[k],
                                                                State.Field[cy + dy[k], cx + dx[k]] - 'А',
                                                                prefixTree[cur.prefixTreeIndex, State.Field[cy + dy[k], cx + dx[k]] - 'А']));
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                // this is OK, do nothing
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        // check if cur is a word
                        if (isWord[cur.prefixTreeIndex])
                        {
                            if (!cur.containsDiagonal())
                            {
                                ++nonDiagonalCounter;
                            }
                            // then add a corresponding move to our list of moves
                            string word = "";
                            while (cur != null)
                            {
                                word = (char)(cur.letter + 'А') + word;
                                cur = cur.parent;
                            }
                            State.ProhibitedWords.Add(word);
                        }
                    }
                }
            }
        }
    }
}
