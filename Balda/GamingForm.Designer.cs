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
            this.button1 = new System.Windows.Forms.Button();
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
            this.fieldDataGridView.Location = new System.Drawing.Point(12, 12);
            this.fieldDataGridView.MultiSelect = false;
            this.fieldDataGridView.Name = "fieldDataGridView";
            this.fieldDataGridView.RowHeadersVisible = false;
            this.fieldDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.fieldDataGridView.ShowEditingIcon = false;
            this.fieldDataGridView.Size = new System.Drawing.Size(200, 200);
            this.fieldDataGridView.TabIndex = 0;
            this.fieldDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.fieldDataGridView_CellEndEdit);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(544, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GamingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 331);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fieldDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GamingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Балда";
            this.Shown += new System.EventHandler(this.GamingForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.fieldDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView fieldDataGridView;
        private System.Windows.Forms.Button button1;
    }
}