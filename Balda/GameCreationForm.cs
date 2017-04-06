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
        private HashSet<string> wordBase;
        private Color[] playerColors = { Color.Red,
                                         Color.Blue,
                                         Color.Green,
                                         Color.Magenta,
                                         Color.Teal,
                                         Color.Chocolate,
                                         Color.Indigo,
                                         Color.DarkOrchid,
                                         Color.DarkRed,
                                         Color.DimGray};
        private string[] computerPlayerNames = { "Альфа",
                                                 "Бета",
                                                 "Гамма",
                                                 "Дельта",
                                                 "Эпсилон",
                                                 "Дзета",
                                                 "Эта",
                                                 "Тета",
                                                 "Йота",
                                                 "Каппа"};

        public GameCreationForm(Dictionary<string, int> users, HashSet<string> wordBase)
        {
            InitializeComponent();
            this.users = users;
            this.wordBase = wordBase;
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
            playerNames[i].MaxLength = 16;
            playerNames[i].ForeColor = playerColors[i];
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
            string startWord = textBoxStartWord.Text.ToUpper();
            if (!wordBase.Contains(startWord))
            {
                MessageBox.Show("Такого слова нет в базе!");
                return;
            }
            int n = playerTypes.Length;
            int m = startWord.Length;
            if (m % 2 == 0)
            {
                MessageBox.Show("Нельзя выбирать слова с чётным количеством букв.");
                return;
            }
            if (!(m * (m - 1) % n == 0))
            {
                MessageBox.Show("С таким словом у игроков будет неодинаковое количество ходов.");
                return;
            }
            List<string> realPlayerNames = new List<string>();
            List<Player> players = new List<Player>();
            for (int i = 0; i < playerTypes.Length; ++i)
            {
                if (playerTypes[i].SelectedText == "Реальный игрок")
                {
                    string realPlayerName = playerNames[i].Text;
                    if (realPlayerName == "")
                    {
                        MessageBox.Show("Вы не ввели имя игрока!");
                        return;
                    }
                    players.Add(new Player(new HumanStrategy(),
                                           realPlayerName,
                                           playerColors[i],
                                           0));
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
                else
                {
                    switch (playerTypes[i].SelectedText)
                    {
                        case "Сильный ИИ":
                            players.Add(new Player(new ComputerStrategy(StrategyStrength.Hard),
                                        "Сильный ИИ " + computerPlayerNames[i],
                                        playerColors[i],
                                        0));
                            break;
                        case "Средний ИИ":
                            players.Add(new Player(new ComputerStrategy(StrategyStrength.Medium),
                                        "Средний ИИ " + computerPlayerNames[i],
                                        playerColors[i],
                                        0));
                            break;
                        case "Слабый ИИ":
                            players.Add(new Player(new ComputerStrategy(StrategyStrength.Easy),
                                        "Слабый ИИ " + computerPlayerNames[i],
                                        playerColors[i],
                                        0));
                            break;
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
            // contruct "Game" object somewhere there
        }

        private void textBoxStartWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letter = e.KeyChar.ToString().ToUpper()[0];
            if (!(letter >= 'А' && letter <= 'Я' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
    }
}
