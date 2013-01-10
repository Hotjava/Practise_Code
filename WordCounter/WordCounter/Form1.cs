using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespacusing WordCounter.FileReaders;
using WordCounter.Propertiespace WordCounter
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
          Resources.Error_The_file_does_not_exist;
            }
            else
            {
                FileReader lReearder = new LineReaders();
                IList<string> s = lReearder.ProcessFile(TxtFilePath.Text);

                LinqCounter counter = new LinqCounter(s.ToList());
                List<WordCount> test = counter.CountWords();
                BindingSource source = new BindingSource();
                source.DataSource = test;
                //source.DataSource = test;
                
                DataGridViewTextBoxColumn wordColumn = new DataGridViewTextBoxColumn();
                
                DataGridViewTextBoxColumn countColumn = new DataGridViewTextBoxColumn();
                

                dataGridView1.Columns.Add(wordColumn);
                dataGridView1.Columns.Add(countColumn);
               
                 test = new List<WordCount>
                           {
                               new WordCount("gsgd",1),
                               new WordCount("dsafd",2)
                           };
                dataGridView1.DataSource = source;

               
              
 void btn_openFile_Click(object sender, EventArgs e)
        {

        }
    }
}
