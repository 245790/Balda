namespace Balda
{
    partial class GamingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fieldDataGridView = new System.Windows.Forms.DataGridView();
            this.buttonShowMainForm = new System.Windows.Forms.Button();
            this.textBoxWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEndTurn = new System.Windows.Forms.Button();
            this.listViewEnterWords = new System.Windows.Forms.ListView();
            this.listViewPlayers = new System.Windows.Forms.ListView();
            this.buttonResetTurn = new System.Windows.Forms.Button();
            this.buttonPassTurn = new System.Windows.Forms.Button();
            this.labelTimer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fieldDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // fieldDataGridView
            // 
            this.fieldDataGridView.AllowUserToAddRows = false;
            this.fieldDataGridView.AllowUserToDeleteRows = false;
            this.fieldDataGridView.AllowUserToResizeColumns = false;
            this.fieldDataGridView.AllowUserToResizeRows = false;
            this.fieldDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fieldDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fieldDataGridView.ColumnHeadersVisible = false;
            this.fieldDataGridView.Location = new System.Drawing.Point(313, 52);
            this.fieldDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fieldDataGridView.MultiSelect = false;
            this.fieldDataGridView.Name = "fieldDataGridView";
            this.fieldDataGridView.RowHeadersVisible = false;
            this.fieldDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.fieldDataGridView.ShowEditingIcon = false;
            this.fieldDataGridView.Size = new System.Drawing.Size(267, 246);
            this.fieldDataGridView.TabIndex = 0;
            this.fieldDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fieldDataGridView_CellClick);
            this.fieldDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.fieldDataGridView_CellEndEdit);
            // 
            // buttonShowMainForm
            // 
            this.buttonShowMainForm.Location = new System.Drawing.Point(668, 15);
            this.buttonShowMainForm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonShowMainForm.Name = "buttonShowMainForm";
            this.buttonShowMainForm.Size = new System.Drawing.Size(207, 28);
            this.buttonShowMainForm.TabIndex = 1;
            this.buttonShowMainForm.Text = "Вернуться на главную";
            this.buttonShowMainForm.UseVisualStyleBackColor = true;
            this.buttonShowMainForm.Click += new System.EventHandler(this.buttonShowMainForm_Click);
            // 
            // textBoxWord
            // 
            this.textBoxWord.Location = new System.Drawing.Point(411, 310);
            this.textBoxWord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxWord.Name = "textBoxWord";
            this.textBoxWord.ReadOnly = true;
            this.textBoxWord.Size = new System.Drawing.Size(168, 22);
            this.textBoxWord.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 314);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ваше слово:";
            // 
            // buttonEndTurn
            // 
            this.buttonEndTurn.Location = new System.Drawing.Point(344, 414);
            this.buttonEndTurn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEndTurn.Name = "buttonEndTurn";
            this.buttonEndTurn.Size = new System.Drawing.Size(207, 28);
            this.buttonEndTurn.TabIndex = 4;
            this.buttonEndTurn.Text = "Закончить ход";
            this.buttonEndTurn.UseVisualStyleBackColor = true;
            this.buttonEndTurn.Click += new System.EventHandler(this.buttonEndTurn_Click);
            // 
            // listViewEnterWords
            // 
            this.listViewEnterWords.LabelWrap = false;
            this.listViewEnterWords.Location = new System.Drawing.Point(16, 52);
            this.listViewEnterWords.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewEnterWords.Name = "listViewEnterWords";
            this.listViewEnterWords.Size = new System.Drawing.Size(205, 389);
            this.listViewEnterWords.TabIndex = 5;
            this.listViewEnterWords.UseCompatibleStateImageBehavior = false;
            this.listViewEnterWords.View = System.Windows.Forms.View.List;
            // 
            // listViewPlayers
            // 
            this.listViewPlayers.Location = new System.Drawing.Point(668, 52);
            this.listViewPlayers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewPlayers.Name = "listViewPlayers";
            this.listViewPlayers.Size = new System.Drawing.Size(205, 389);
            this.listViewPlayers.TabIndex = 5;
            this.listViewPlayers.UseCompatibleStateImageBehavior = false;
            this.listViewPlayers.View = System.Windows.Forms.View.List;
            // 
            // buttonResetTurn
            // 
            this.buttonResetTurn.Location = new System.Drawing.Point(344, 342);
            this.buttonResetTurn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonResetTurn.Name = "buttonResetTurn";
            this.buttonResetTurn.Size = new System.Drawing.Size(207, 28);
            this.buttonResetTurn.TabIndex = 7;
            this.buttonResetTurn.Text = "Вернуться к началу хода";
            this.buttonResetTurn.UseVisualStyleBackColor = true;
            this.buttonResetTurn.Click += new System.EventHandler(this.buttonResetTurn_Click);
            // 
            // buttonPassTurn
            // 
            this.buttonPassTurn.Location = new System.Drawing.Point(344, 379);
            this.buttonPassTurn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPassTurn.Name = "buttonPassTurn";
            this.buttonPassTurn.Size = new System.Drawing.Size(207, 28);
            this.buttonPassTurn.TabIndex = 8;
            this.buttonPassTurn.Text = "Пропустить ход";
            this.buttonPassTurn.UseVisualStyleBackColor = true;
            this.buttonPassTurn.Click += new System.EventHandler(this.buttonPassTurn_Click);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(429, 21);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(44, 17);
            this.labelTimer.TabIndex = 9;
            this.labelTimer.Text = "Timer";
            // 
            // GamingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 519);
            this.ControlBox = false;
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.buttonPassTurn);
            this.Controls.Add(this.buttonResetTurn);
            this.Controls.Add(this.listViewPlayers);
            this.Controls.Add(this.listViewEnterWords);
            this.Controls.Add(this.buttonEndTurn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxWord);
            this.Controls.Add(this.buttonShowMainForm);
            this.Controls.Add(this.fieldDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GamingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Балда";
            this.Shown += new System.EventHandler(this.GamingForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.fieldDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView fieldDataGridView;
        private System.Windows.Forms.Button buttonShowMainForm;
        private System.Windows.Forms.TextBox textBoxWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEndTurn;
        private System.Windows.Forms.ListView listViewEnterWords;
        private System.Windows.Forms.ListView listViewPlayers;
        private System.Windows.Forms.Button buttonResetTurn;
        private System.Windows.Forms.Button buttonPassTurn;
        private System.Windows.Forms.Label labelTimer;
    }
}