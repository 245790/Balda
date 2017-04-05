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
    public partial class GameCreationForm : Form
    {
        private TextBox[] playerNames;
        private ComboBox[] playerTypes;

        public GameCreationForm()
        {
            InitializeComponent();
            playerNames = new TextBox[2];
            playerTypes = new ComboBox[2];
            for (int i = 0; i < 2; ++i)
            {
                playerNames[i] = new TextBox();
                playerNames[i].Size = new Size(140, 16);
                playerNames[i].Text = "Как вас зовут?";
                playerNames[i].Location = i % 2 == 0 ? new Point(10, 36 + i / 2 * 16 + (i / 2 + 1) * 10) : new Point(310, 36 + i / 2 * 16 + (i / 2 + 1) * 10);
                playerTypes[i] = new ComboBox();
                playerTypes[i].Size = new Size(130, 16);
                playerTypes[i].Location = i % 2 == 0 ? new Point(160, 36 + i / 2 * 16 + (i / 2 + 1) * 10) : new Point(460, 36 + i / 2 * 16 + (i / 2 + 1) * 10);
                playerTypes[i].Items.Add("Реальный игрок");
                playerTypes[i].Items.Add("Слабый ИИ");
                playerTypes[i].Items.Add("Средний ИИ");
                playerTypes[i].Items.Add("Сильный ИИ");
                playerTypes[i].SelectedText = "Реальный игрок";
                playerNames[i].Parent = this;
                playerTypes[i].Parent = this;
                playerNames[i].Show();
                playerTypes[i].Show();
            }
        }

        private void buttonShowMainForm_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            Close();
        }

        private void numericUpDownPlayersCount_ValueChanged(object sender, EventArgs e)
        {
            /*if (numericUpDownPlayersCount.Value - playerNames.Length == 1) // increased
            {
                Array.Resize(ref playerNames, 
            }*/
        }
    }
}
