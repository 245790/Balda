using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balda
{
    class Move
    {
        private List<int> x;
        private List<int> y;

        public Move()
        {
            x = new List<int>();
            y = new List<int>();
        }

        public void addLetter(int x, int y)
        {
            this.x.Add(x);
            this.y.Add(y);
        }

        public List<int> getX()
        {
            return x;
        }

        public List<int> getY()
        {
            return y;
        }
    }
}
