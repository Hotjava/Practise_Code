using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordCounter
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_openFile_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            TxtFilePath.Text = openFileDialog1.FileName;
        }

        private void Btn_CountWord_Click(object sender, EventArgs e)
        {
            Lbl_Message.Text = string.Empty;
            if (!File.Exists(TxtFilePath.Text))
            {
                Lbl_Message.Text = "The file does not exist";
            }
            else
            {
                
            }
        }

        private void btn_openFile_Click(object sender, EventArgs e)
        {

        }
    }
}
