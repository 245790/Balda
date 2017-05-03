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
            this.fieldDataGridView.Location = new System.Drawing.Point(212, 12);
            this.fieldDataGridView.MultiSelect = false;
            this.fieldDataGridView.Name = "fieldDataGridView";
            this.fieldDataGridView.RowHeadersVisible = false;
            this.fieldDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.fieldDataGridView.ShowEditingIcon = false;
            this.fieldDataGridView.Size = new System.Drawing.Size(200, 200);
            this.fieldDataGridView.TabIndex = 0;
            this.fieldDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fieldDataGridView_CellClick);
            this.fieldDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.fieldDataGridView_CellEndEdit);
            // 
            // buttonShowMainForm
            // 
            this.buttonShowMainForm.Location = new System.Drawing.Point(501, 12);
            this.buttonShowMainForm.Name = "buttonShowMainForm";
            this.buttonShowMainForm.Size = new System.Drawing.Size(155, 23);
            this.buttonShowMainForm.TabIndex = 1;
            this.buttonShowMainForm.Text = "Вернуться на главную";
            this.buttonShowMainForm.UseVisualStyleBackColor = true;
            this.buttonShowMainForm.Click += new System.EventHandler(this.buttonShowMainForm_Click);
            // 
            // textBoxWord
            // 
            this.textBoxWord.Location = new System.Drawing.Point(285, 231);
            this.textBoxWord.Name = "textBoxWord";
            this.textBoxWord.Size = new System.Drawing.Size(127, 20);
            this.textBoxWord.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ваше слово:";
            // 
            // GamingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 331);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxWord);
            this.Controls.Add(this.buttonShowMainForm);
            this.Controls.Add(this.fieldDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
    }
}