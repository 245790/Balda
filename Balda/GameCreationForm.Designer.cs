namespace Balda
{
    partial class GameCreationForm
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
            this.labelHowManyPlayers = new System.Windows.Forms.Label();
            this.numericUpDownPlayersCount = new System.Windows.Forms.NumericUpDown();
            this.buttonShowMainForm = new System.Windows.Forms.Button();
            this.buttonCreateGame = new System.Windows.Forms.Button();
            this.labelStartWord = new System.Windows.Forms.Label();
            this.textBoxStartWord = new System.Windows.Forms.TextBox();
            this.checkBoxAllowDiagonal = new System.Windows.Forms.CheckBox();
            this.checkBoxAllowIntersections = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownTimeLimit = new System.Windows.Forms.NumericUpDown();
            this.checkBoxAllowRepeats = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHowManyPlayers
            // 
            this.labelHowManyPlayers.AutoSize = true;
            this.labelHowManyPlayers.Location = new System.Drawing.Point(10, 10);
            this.labelHowManyPlayers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHowManyPlayers.Name = "labelHowManyPlayers";
            this.labelHowManyPlayers.Size = new System.Drawing.Size(125, 16);
            this.labelHowManyPlayers.TabIndex = 0;
            this.labelHowManyPlayers.Text = "Сколько игроков?";
            // 
            // numericUpDownPlayersCount
            // 
            this.numericUpDownPlayersCount.Location = new System.Drawing.Point(141, 7);
            this.numericUpDownPlayersCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownPlayersCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownPlayersCount.Name = "numericUpDownPlayersCount";
            this.numericUpDownPlayersCount.ReadOnly = true;
            this.numericUpDownPlayersCount.Size = new System.Drawing.Size(42, 22);
            this.numericUpDownPlayersCount.TabIndex = 1;
            this.numericUpDownPlayersCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownPlayersCount.ValueChanged += new System.EventHandler(this.numericUpDownPlayersCount_ValueChanged);
            // 
            // buttonShowMainForm
            // 
            this.buttonShowMainForm.Location = new System.Drawing.Point(388, 9);
            this.buttonShowMainForm.Name = "buttonShowMainForm";
            this.buttonShowMainForm.Size = new System.Drawing.Size(194, 26);
            this.buttonShowMainForm.TabIndex = 2;
            this.buttonShowMainForm.Text = "Вернуться на главную";
            this.buttonShowMainForm.UseVisualStyleBackColor = true;
            this.buttonShowMainForm.Click += new System.EventHandler(this.buttonShowMainForm_Click);
            // 
            // buttonCreateGame
            // 
            this.buttonCreateGame.Location = new System.Drawing.Point(462, 377);
            this.buttonCreateGame.Name = "buttonCreateGame";
            this.buttonCreateGame.Size = new System.Drawing.Size(120, 32);
            this.buttonCreateGame.TabIndex = 3;
            this.buttonCreateGame.Text = "Создать игру";
            this.buttonCreateGame.UseVisualStyleBackColor = true;
            this.buttonCreateGame.Click += new System.EventHandler(this.buttonCreateGame_Click);
            // 
            // labelStartWord
            // 
            this.labelStartWord.AutoSize = true;
            this.labelStartWord.Location = new System.Drawing.Point(10, 210);
            this.labelStartWord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStartWord.Name = "labelStartWord";
            this.labelStartWord.Size = new System.Drawing.Size(121, 16);
            this.labelStartWord.TabIndex = 4;
            this.labelStartWord.Text = "Стартовое слово";
            // 
            // textBoxStartWord
            // 
            this.textBoxStartWord.Location = new System.Drawing.Point(136, 207);
            this.textBoxStartWord.MaxLength = 15;
            this.textBoxStartWord.Name = "textBoxStartWord";
            this.textBoxStartWord.Size = new System.Drawing.Size(116, 22);
            this.textBoxStartWord.TabIndex = 5;
            this.textBoxStartWord.Text = "НАНОС";
            this.textBoxStartWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxStartWord_KeyPress);
            // 
            // checkBoxAllowDiagonal
            // 
            this.checkBoxAllowDiagonal.AutoSize = true;
            this.checkBoxAllowDiagonal.Location = new System.Drawing.Point(13, 243);
            this.checkBoxAllowDiagonal.Name = "checkBoxAllowDiagonal";
            this.checkBoxAllowDiagonal.Size = new System.Drawing.Size(165, 20);
            this.checkBoxAllowDiagonal.TabIndex = 6;
            this.checkBoxAllowDiagonal.Text = "Ходить по диагонали";
            this.checkBoxAllowDiagonal.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllowIntersections
            // 
            this.checkBoxAllowIntersections.AutoSize = true;
            this.checkBoxAllowIntersections.Location = new System.Drawing.Point(12, 269);
            this.checkBoxAllowIntersections.Name = "checkBoxAllowIntersections";
            this.checkBoxAllowIntersections.Size = new System.Drawing.Size(224, 20);
            this.checkBoxAllowIntersections.TabIndex = 7;
            this.checkBoxAllowIntersections.Text = "Пересекать слово само собой";
            this.checkBoxAllowIntersections.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Задать лимит времени (в минутах)";
            // 
            // numericUpDownTimeLimit
            // 
            this.numericUpDownTimeLimit.Location = new System.Drawing.Point(12, 345);
            this.numericUpDownTimeLimit.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownTimeLimit.Name = "numericUpDownTimeLimit";
            this.numericUpDownTimeLimit.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownTimeLimit.TabIndex = 9;
            // 
            // checkBoxAllowRepeats
            // 
            this.checkBoxAllowRepeats.AutoSize = true;
            this.checkBoxAllowRepeats.Checked = true;
            this.checkBoxAllowRepeats.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAllowRepeats.Location = new System.Drawing.Point(12, 295);
            this.checkBoxAllowRepeats.Name = "checkBoxAllowRepeats";
            this.checkBoxAllowRepeats.Size = new System.Drawing.Size(430, 20);
            this.checkBoxAllowRepeats.TabIndex = 10;
            this.checkBoxAllowRepeats.Text = "Можно ли ставить слова, которые сами составились на поле?";
            this.checkBoxAllowRepeats.UseVisualStyleBackColor = true;
            // 
            // GameCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 421);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxAllowRepeats);
            this.Controls.Add(this.numericUpDownTimeLimit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxAllowIntersections);
            this.Controls.Add(this.checkBoxAllowDiagonal);
            this.Controls.Add(this.textBoxStartWord);
            this.Controls.Add(this.labelStartWord);
            this.Controls.Add(this.buttonCreateGame);
            this.Controls.Add(this.buttonShowMainForm);
            this.Controls.Add(this.numericUpDownPlayersCount);
            this.Controls.Add(this.labelHowManyPlayers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameCreationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание игры";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHowManyPlayers;
        private System.Windows.Forms.NumericUpDown numericUpDownPlayersCount;
        private System.Windows.Forms.Button buttonShowMainForm;
        private System.Windows.Forms.Button buttonCreateGame;
        private System.Windows.Forms.Label labelStartWord;
        private System.Windows.Forms.TextBox textBoxStartWord;
        private System.Windows.Forms.CheckBox checkBoxAllowDiagonal;
        private System.Windows.Forms.CheckBox checkBoxAllowIntersections;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeLimit;
        private System.Windows.Forms.CheckBox checkBoxAllowRepeats;
    }
}