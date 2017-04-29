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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayersCount)).BeginInit();
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
            this.buttonCreateGame.Location = new System.Drawing.Point(462, 348);
            this.buttonCreateGame.Name = "buttonCreateGame";
            this.buttonCreateGame.Size = new System.Drawing.Size(120, 23);
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
            this.textBoxStartWord.Text = "АББАТ";
            this.textBoxStartWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxStartWord_KeyPress);
            // 
            // GameCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 383);
            this.ControlBox = false;
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
    }
}