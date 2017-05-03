using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Balda
{
    public class Rules
    {
        public bool AllowDiagonal { get; private set;}
        public bool AllowIntersections { get; private set; }
        public bool AllowRepeats { get; private set; }
        public bool HasTimeLimit { get; private set; }
        public int TimeLimit { get; private set; }
        public Rules()
        {
            AllowRepeats = true;
        }
        public Rules(bool allowDiagonal,
                     bool allowIntersections,
                     bool allowRepeats,
                     bool hasTimeLimit,
                     int timeLimit)
        {
            AllowDiagonal = allowDiagonal;
            AllowIntersections = allowIntersections;
            AllowRepeats = allowRepeats;
            HasTimeLimit = hasTimeLimit;
            TimeLimit = timeLimit;
        }

        public bool isNeighbours(int x1, int y1, int x2, int y2)
        {
            int[] dx, dy;
            if (this.AllowDiagonal == true)
            {
                dx = new int[] { 1, 0, -1, 0, 1, 1, -1, -1 };
                dy = new int[] { 0, 1, 0, -1, 1, -1, 1, -1 };
            }
            else
            {
                dx = new int[] { 1, 0, -1, 0 };
                dy = new int[] { 0, 1, 0, -1 };
            }
            for (int k = 0; k < dx.Length; ++k)
            {
                try
                {
                    if (y1 + dy[k] == y2 && x1 + dx[k] == x2)
                    {
                        return true;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            return false;
        }

        public bool[,] findAvailableCells(FieldState field)
        {
            bool[,] result = new bool[field.Field.GetLength(0), field.Field.GetLength(1)];
            int[] dx, dy;
            if (this.AllowDiagonal == true)
            {
                dx = new int[] { 1, 0, -1,  0, 1,  1, -1, -1 };
                dy = new int[] { 0, 1,  0, -1, 1, -1,  1, -1 };
            }
            else
            {
                dx = new int[] { 1, 0, -1,  0 };
                dy = new int[] { 0, 1,  0, -1 };
            }
            char nullLetter = '\0';
            for (int i = 0; i < field.Field.GetLength(0); ++i)
            {
                for (int j = 0; j < field.Field.GetLength(1); ++j)
                {
                    if (field.Field[i, j] != nullLetter)
                    {
                        for (int k = 0; k < dx.Length; ++k)
                        {
                            try
                            {
                                if (field.Field[i + dy[k], j + dx[k]] == nullLetter)
                                {
                                    result[i + dy[k], j + dx[k]] = true;
                                }
                            }
                            catch(IndexOutOfRangeException)
                            {
                                // this is OK, do nothing
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
            return result;
        }
    }    
}
