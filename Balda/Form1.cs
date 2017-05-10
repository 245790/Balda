using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Balda
{
    public partial class Form1 : Form
    {
        private Dictionary<string, int> users; // NAME -> RATING

        private WordBase wordBase;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("../../users.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            users = (Dictionary<string, int>)formatter.Deserialize(stream);
            stream.Close();

            Stream stream2 = new FileStream("../../wordBase.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            wordBase = (WordBase)formatter.Deserialize(stream2);
            stream2.Close();

            /*
            // Это чтобы преобразовать текстовый файл в сериализуемый бинарник
            string[] lines = System.IO.File.ReadAllLines(@"../../word_rus.txt");
            WordBase wb = new WordBase();
            foreach (string word in lines)
            {
                
                if (!word.Contains('-'))
                {
                    wb.Add(word.ToUpper());
                }
            }
            IFormatter formatter2 = new BinaryFormatter();
            Stream stream2 = new FileStream("../../wordBase.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream2, wb);
            stream2.Close();*/
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("../../users.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, users);
            stream.Close();  
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены в том, что хотите выйти?",
                                         "Подтверждение выхода",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void createGameButton_Click(object sender, EventArgs e)
        {
            GameCreationForm g = new GameCreationForm(users, wordBase);
            g.Owner = this;
            this.Hide();
            g.Show();
        }
    }
}
