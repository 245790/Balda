using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balda
{
    class HumanStrategy : IStrategy
    {
        private GamingForm gamingForm;

        public HumanStrategy(GamingForm gamingForm)
        {
            this.gamingForm = gamingForm;
        }

        public void move(FieldState field, ref Move move, Rules rules)
        {
            do
            {
                move = gamingForm.HumanMove;
            }
            while (move == null);
            // ↓ А это просто красиво.
            // while ((move = gamingForm.HumanMove) == null);
            return;
        }
    }
}
