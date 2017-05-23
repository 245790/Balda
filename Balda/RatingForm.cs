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
    public partial class RatingForm : Form
    {
        public RatingForm(Dictionary<string, int> users)
        {
            InitializeComponent();
            dataGridViewRating.ColumnCount = 3;
            dataGridViewRating.RowCount = users.Count;
            dataGridViewRating.Columns[0].HeaderText = "Место";
            dataGridViewRating.Columns[1].HeaderText = "Имя игрока";
            dataGridViewRating.Columns[2].HeaderText = "Баллы";
            List<KeyValuePair<string, int>> usersList = new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, int> user in users)
            {
                usersList.Add(new KeyValuePair<string, int>(user.Key, user.Value));                
            }
            usersList.Sort((p1, p2) => p2.Value - p1.Value);
            for (int i = 0; i < usersList.Count; i++) 
            {
                dataGridViewRating.Rows[i].Cells[0].Value = (i + 1).ToString();
                dataGridViewRating.Rows[i].Cells[1].Value = usersList[i].Key;
                dataGridViewRating.Rows[i].Cells[2].Value = usersList[i].Value.ToString();
            }
        }

        private void buttonShowMainForm_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            Close();
        }
    }
}
