using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balda
{
    public interface IStrategy
    {
        void move(FieldState state, ref Move move, Rules rules);
    }
}
