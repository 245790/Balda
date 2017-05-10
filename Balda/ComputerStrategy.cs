using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Balda
{
    enum StrategyStrength { Easy, Medium, Hard };

    class ComputerStrategy : IStrategy
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

        private const int prefixTreeMaxSize = 19168; // this is the number of tree nodes needed to store all our word base
        private StrategyStrength str;
        private int[,] prefixTree = new int[prefixTreeMaxSize, 32]; // 32 letters in russian alphabet (without Ё)
        private bool[] isWord = new bool[prefixTreeMaxSize];
        private Stack<Move> optimalMove;
        private List<Stack<Move>> possibleMoves; // possible sequences of moves
        private GamingForm gamingForm;

        private List<string> words;

        public ComputerStrategy(StrategyStrength str, GamingForm gamingForm)
        {
            words = new List<string>();

            this.gamingForm = gamingForm;
            this.str = str;
            optimalMove = new Stack<Move>();
            possibleMoves = new List<Stack<Move>>();
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

        private bool isCapitalRussianLetter(Char letter)
        {
            return letter >= 'А' && letter <= 'Я';
        }

        public void move(FieldState state, ref Move move, Rules rules)
        {
            gamingForm.updateForm(state, rules);
            System.Threading.Thread.Sleep(700);
            if (optimalMove.Count == 0) // this holds only on the first move of the iteration
            {
                int nonDiagonalCounter = 0;
                // then find the optimal move
                int width = state.Field.GetLength(0);
                int[] dx, dy;
                if (rules.AllowDiagonal == true)
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
                        if (state.Field[i, j] == '\0')
                        {
                            // if there is space in the current cell
                            for (int k = 0; k < 32; ++k)
                            {
                                // add every possible letter
                                if (prefixTree[0, k] != -1)
                                {
                                    st.Push(new FieldTreeNode(true, true, null, j, i, k, prefixTree[0, k]));
                                }
                            }
                        }
                        else
                        {
                            // there is only one possible start node
                            // if there are words that start with this letter
                            if (prefixTree[0, state.Field[i, j] - 'А'] != -1)
                            {
                                st.Push(new FieldTreeNode(false,
                                                          false,
                                                          null,
                                                          j,
                                                          i,
                                                          state.Field[i, j] - 'А',
                                                          prefixTree[0, state.Field[i, j] - 'А']));
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
                                    if (!rules.AllowIntersections)
                                    {
                                        if (cur.containsCoords(cx + dx[k], cy + dy[k]))
                                        {
                                            continue;
                                        }
                                    }
                                    // if the neighbour contains a space and it can be filled with a new letter
                                    if (state.Field[cy + dy[k], cx + dx[k]] == '\0' && !cur.newLetterUsed)
                                    {
                                        for (int l = 0; l < 32; ++l)
                                        {
                                            if (prefixTree[cur.prefixTreeIndex, l] != -1)
                                            {
                                                st.Push(new FieldTreeNode(true,
                                                                          true,
                                                                          cur,
                                                                          cx + dx[k],
                                                                          cy + dy[k],
                                                                          l,
                                                                          prefixTree[cur.prefixTreeIndex, l]));
                                            }
                                        }
                                    }
                                    // if the neighbour contains a letter and there is a corresponding prefix
                                    if (isCapitalRussianLetter(state.Field[cy + dy[k], cx + dx[k]])
                                        && prefixTree[cur.prefixTreeIndex, state.Field[cy + dy[k], cx + dx[k]] - 'А'] != -1)
                                    {
                                        st.Push(new FieldTreeNode(false,
                                                                  cur.newLetterUsed,
                                                                  cur,
                                                                  cx + dx[k],
                                                                  cy + dy[k],
                                                                  state.Field[cy + dy[k], cx + dx[k]] - 'А',
                                                                  prefixTree[cur.prefixTreeIndex, state.Field[cy + dy[k], cx + dx[k]] - 'А']));
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
                            if (isWord[cur.prefixTreeIndex] && cur.newLetterUsed == true)
                            {
                                if (!cur.containsDiagonal())
                                {
                                    ++nonDiagonalCounter;
                                }
                                // then add a corresponding move to our list of moves
                                FieldTreeNode newLetter = cur.findNewLetter();
                                Stack<Move> newWord = new Stack<Move>();
                                Move lol = new Move();
                                lol.Action = ActionType.EndTurn;
                                newWord.Push((Move)lol.Clone());
                                string word = "";
                                while (cur != null)
                                {
                                    word = (char)(cur.letter + 'А') + word;

                                    lol.Action = ActionType.SelectLetter;
                                    lol.X = cur.x;
                                    lol.Y = cur.y;
                                    newWord.Push((Move)lol.Clone());
                                    cur = cur.parent;
                                }
                                lol.Action = ActionType.EnterLetter;
                                lol.X = newLetter.x;
                                lol.Y = newLetter.y;
                                lol.Letter = (char)(newLetter.letter + 'А');
                                newWord.Push((Move)lol.Clone());
                                // we cannot place words from ProhibitedWords, so check this
                                if (!state.ProhibitedWords.Contains(word))
                                {
                                    words.Add(word);
                                    possibleMoves.Add(newWord);
                                }
                            }
                        }
                    }
                }
                if (possibleMoves.Count == 0) // we have not found any possible word
                {
                    // in this case we can only pass a turn
                    Move tmp = new Move();
                    tmp.Action = ActionType.PassTurn;
                    optimalMove.Push(tmp);
                }
                else
                {
                    possibleMoves.Sort((list1, list2) => list1.Count - list2.Count);
                    int optimalIndex = 0;
                    switch (str)
                    {
                        case StrategyStrength.Easy:
                            optimalIndex = 0;
                            break;
                        case StrategyStrength.Medium:
                            optimalIndex = possibleMoves.Count / 2;
                            break;
                        case StrategyStrength.Hard:
                            optimalIndex = possibleMoves.Count - 1;
                            break;
                    }
                    optimalMove = possibleMoves[optimalIndex];
                }
                move = optimalMove.Pop();
            }
            else
            {
                move = optimalMove.Pop();
                if (optimalMove.Count == 0)
                {
                    possibleMoves.Clear();
                }
            }
            return;
        }
    }
}
