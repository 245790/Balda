using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Balda
{
    public class Player
    {
        public IStrategy Strategy { get; private set; }
        public string Name { get; private set; }
        public Color PlayerColor { get; private set; }
        public int Score { get; set; }

        public Player(IStrategy strategy, string name, Color color, int score)
        {
            this.Strategy = strategy;
            this.Name = name;
            this.PlayerColor = color;
            this.Score = score;
        }
    }
}
