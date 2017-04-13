using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balda
{
    enum StrategyStrength { Easy, Medium, Hard };

    class ComputerStrategy : IStrategy
    {
        private StrategyStrength str;

        public ComputerStrategy(StrategyStrength str)
        {
            this.str = str;
        }

        public void move(FieldState field, ref Move move, Rules rules)
        {
            // check the str variable before choosing the word
            return;
        }
    }
}
