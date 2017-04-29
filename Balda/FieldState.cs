using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balda
{
    public class FieldState
    {
        public char[,] Field { get; set; }
        public int NewX { get; set; }
        public int NewY { get; set; }
        public List<int> X { get; set; }
        public List<int> Y { get; set; }
        public FieldState (string startWord)
        {
            int wordLen = startWord.Length;
            Field = new char[wordLen, wordLen];
            for (int i = 0; i < wordLen; i++)
            {
                for (int j = 0; j < wordLen; j++)
                {
                    if (i == wordLen / 2)
                    {
                        Field[i, j] = startWord[j];
                    }
                    else
                    {
                        Field[i, j] = ' ';
                    }                    
                }
            }
            X = new List<int>();
            Y = new List<int>();
            NewX = -1;
            NewY = -1;
        }
    }
}
