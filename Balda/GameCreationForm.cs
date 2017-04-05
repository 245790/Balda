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
        private int defaultRating = 1600;
        private TextBox[] playerNames;
        private ComboBox[] playerTypes;
        private Dictionary<string, int> users;

        public GameCreationForm(Dictionary<string, int> users)
        {
            InitializeComponent();
            this.users = users;
            playerNames = new TextBox[2];
            playerTypes = new ComboBox[2];
            for (int i = 0; i < 2; ++i)
            {
                createUserInputControls(i);
            }
        }

        private void createUserInputControls(int i)
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

        private void hideUserInputControls(int i)
        {
            playerNames[i].Hide();
            playerTypes[i].Hide();
        }

        private void buttonShowMainForm_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            Close();
        }

        private void numericUpDownPlayersCount_ValueChanged(object sender, EventArgs e)
        {
            int oldSize = playerNames.Length;
            int newSize = (int)numericUpDownPlayersCount.Value;
            if (newSize - oldSize == -1) // decreased
            {
                hideUserInputControls(oldSize - 1);
            }
            Array.Resize(ref playerNames, newSize);
            Array.Resize(ref playerTypes, newSize);
            if (newSize - oldSize == 1) // increased
            {
                createUserInputControls(newSize - 1);
            }
        }

        private void buttonCreateGame_Click(object sender, EventArgs e)
        {
            List<string> realPlayerNames = new List<string>();
            for (int i = 0; i < playerTypes.Length; ++i)
            {
                if (playerTypes[i].SelectedText == "Реальный игрок")
                {
                    string realPlayerName = playerNames[i].Text;
                    if (!realPlayerNames.Contains(realPlayerName))
                    {
                        realPlayerNames.Add(realPlayerName);
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели одно или несколько одинаковых имён реальных игроков");
                        return;
                    }
                }
            }
            foreach (string realPlayerName in realPlayerNames)
            {
                if (!users.ContainsKey(realPlayerName))
                {
                    users.Add(realPlayerName, defaultRating);
                }
            }
            // don't forget to construct Player objects somewhere in this method
        }
    }
}
