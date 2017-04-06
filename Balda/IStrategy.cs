using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balda
{
    interface IStrategy
    {
        void move(char[,] field, ref Move move);
    }
}
