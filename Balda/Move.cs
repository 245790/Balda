using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balda
{
    class Move
    {
        enum ActionType { EnterLetter, SelectLetter, EndTurn, PassTurn, Reset, UnknownAction };
        public int X { get; set; }
        public int Y { get; set; }
        public char Letter { get; set; }
        public ActionType Action { get; set; }
        public Move()
        {
            Action = ActionType.UnknownAction;
        }       
    }
}
