using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balda
{
    enum ActionType { EnterLetter, SelectLetter, EndTurn, PassTurn, Reset, UnknownAction };
    class Move
    {        
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
