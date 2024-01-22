using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace LAB2
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }



        private void Bai2_Load(object sender, EventArgs e)
        {

        }
        //Tên file
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //URL
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //Số cột
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //Số dòng
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        //Số ký tự 
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            //Name
            Name = ofd.SafeFileName.ToString();
            textBox1.Text = Name;

            //Url
            string  url = fs.Name.ToString();
            textBox2.Text = url;

            //Number of character        
            string content = sr.ReadToEnd();
            RichTextBox.Text = content;
            int charCount = content.Length;
            textBox5.Text = charCount.ToString();

            //Number of lines in the text
            int lineCount = 0;
            content = content.Replace("\r\n", "\r");
            lineCount = RichTextBox.Lines.Count();
            content = content.Replace('\r', ' ');
            textBox3.Text = lineCount.ToString();

            //Number of word
            string[] source = content.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = source.Count();
            textBox4.Text = wordCount.ToString();
            fs.Close();
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
