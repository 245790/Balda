using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }    
}
