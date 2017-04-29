using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balda
{
    public enum ActionType { EnterLetter, SelectLetter, EndTurn, PassTurn, Reset, UnknownAction };
    public class Move : ICloneable
    {        
        public int X { get; set; }
        public int Y { get; set; }
        public char Letter { get; set; }
        public ActionType Action { get; set; }

        public Move()
        {
            Action = ActionType.UnknownAction;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return String.Format("X = {0} Y = {1} Letter = {2} Action = {3}", X.ToString(), Y.ToString(), Letter.ToString(), Action.ToString());
        }
    }
}
