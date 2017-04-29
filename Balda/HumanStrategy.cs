using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            gamingForm.updateForm(field, rules);
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
