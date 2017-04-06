using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Balda
{
    class Player
    {
        public IStrategy Strategy { get; private set; }
        public string Name { get; private set; }
        public Color PlayerColor { get; private set; }
        public int Score { get; private set; }

        public Player(IStrategy strategy, string name, Color color, int score)
        {
            this.Strategy = strategy;
            this.Name = name;
            this.PlayerColor = color;
            this.Score = score;
        }
    }
}
