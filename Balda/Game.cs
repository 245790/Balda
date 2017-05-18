using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Balda
{
    public class Game
    {
        public FieldState State { get;  private set; }
        public Rules Rules { get; private set; }
        public List<Player> Players { get; private set; }
        private WordBase wordBase;
        private GamingForm gamingForm;
        private int consequtiveTurnPasses;

        public Game(string startWord, List<Player> players, Rules rules, WordBase wordBase, GamingForm gamingForm)
        {
            State = new FieldState(startWord);
            Rules = rules;
            Players = players;
            this.wordBase = wordBase;
            this.gamingForm = gamingForm;
            consequtiveTurnPasses = 0;
        }

        public void play(ref List<KeyValuePair<int, Player>> result) 
        {
            bool gameEnded = false;
            while (!gameEnded) 
            {
                int i = 0;
                foreach (Player player in Players) 
                {
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

        private void processPlayer(Player player, int currentIndex)
        {
            bool correctEndTurn = false;
            Move move = new Move();
            MessageBox.Show("Ходит игрок " + player.Name);
            gamingForm.updatePlayersScore(Players, currentIndex);
            do
            {
                gamingForm.updateForm(State, Rules);
                player.Strategy.move(State, ref move, Rules);                
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
                        if (Rules.isNeighbours(x, y, State.X[wordLength-1], State.Y[wordLength-1]))
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
    }
}
