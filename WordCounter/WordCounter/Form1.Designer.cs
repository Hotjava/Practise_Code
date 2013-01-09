namespace WordCounter
{
    partial class Form1
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
            this.TxtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_openFile = new System.Windows.Forms.Button();
            this.Btn_CountWord = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Lbl_Message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtFilePath
            // 
            this.TxtFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFilePath.Location = new System.Drawing.Point(52, 13);
            this.TxtFilePath.Name = "TxtFilePath";
            this.TxtFilePath.Size = new System.Drawing.Size(280, 21);
            this.TxtFilePath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "File";
            // 
            // Btn_openFile
            // 
            this.Btn_openFile.AutoSize = true;
            this.Btn_openFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_openFile.Location = new System.Drawing.Point(338, 9);
            this.Btn_openFile.Name = "Btn_openFile";
            this.Btn_openFile.Size = new System.Drawing.Size(31, 30);
            this.Btn_openFile.TabIndex = 2;
            this.Btn_openFile.Text = "...";
            this.Btn_openFile.UseVisualStyleBackColor = true;
            this.Btn_openFile.Click += new System.EventHandler(this.Btn_openFile_Click);
            // 
            // Btn_CountWord
            // 
            this.Btn_CountWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_CountWord.Location = new System.Drawing.Point(116, 54);
            this.Btn_CountWord.Name = "Btn_CountWord";
            this.Btn_CountWord.Size = new System.Drawing.Size(130, 23);
            this.Btn_CountWord.TabIndex = 3;
            this.Btn_CountWord.Text = "Count Word";
            this.Btn_CountWord.UseVisualStyleBackColor = true;
            this.Btn_CountWord.Click += new System.EventHandler(this.Btn_CountWord_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "text files|*.txt";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // Lbl_Message
            // 
            this.Lbl_Message.AutoSize = true;
            this.Lbl_Message.Location = new System.Drawing.Point(12, 85);
            this.Lbl_Message.Name = "Lbl_Message";
            this.Lbl_Message.Size = new System.Drawing.Size(0, 13);
            this.Lbl_Message.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 386);
            this.Controls.Add(this.Lbl_Message);
            this.Controls.Add(this.Btn_CountWord);
            this.Controls.Add(this.Btn_openFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtFilePath);
            this.Name = "Form1";
            this.Text = "Word Counter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_openFile;
        private System.Windows.Forms.Button Btn_CountWord;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label Lbl_Message;
    }
}

