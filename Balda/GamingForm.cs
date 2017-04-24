using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Balda
{
    public partial class GamingForm : Form
    {
        private Move humanMove;
        public Move HumanMove
        {
            get
            {
                if (humanMove == null)
                {
                    return null;
                }
                Move moveCopy = (Move)humanMove.Clone();
                humanMove = null;
                return moveCopy;
            }
            private set
            {
                humanMove = value;
            }
        }

        private Game game;
        public Game Game
        {
            set
            {
                game = value;
            }
        }

        public GamingForm()
        {
            InitializeComponent();
        }

        private void GamingForm_Shown(object sender, EventArgs e)
        {
            game.play();
        }
    }
}
