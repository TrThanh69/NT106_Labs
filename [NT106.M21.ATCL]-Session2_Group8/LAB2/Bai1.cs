using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }



        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Bai1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)//read
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string content = sr.ReadToEnd();
            RichTextBox.Text = content;
            fs.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)//write
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            FileStream fs = new FileStream(sfd.FileName, FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            string Upwwords = RichTextBox.Text;
            Upwwords = Upwwords.ToUpper();
            sw.WriteLine(Upwwords);
            sw.Flush();
            fs.Close();
        }
    }
}
