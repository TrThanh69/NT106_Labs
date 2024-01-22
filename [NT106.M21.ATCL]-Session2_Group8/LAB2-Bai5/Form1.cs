using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace bai5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowDialog();
                DirectoryInfo di = new DirectoryInfo(fbd.SelectedPath);
                FileInfo[] fi = di.GetFiles();
                foreach (FileInfo file in fi)
                {
                    ListViewItem ds = new ListViewItem();
                    ds.Text = file.Name;
                    ds.SubItems.Add(file.Length.ToString());
                    ds.SubItems.Add(file.Extension);
                    ds.SubItems.Add(file.CreationTime.ToString());
                    listView1.Items.Add(ds);
                }
            }
            catch (Exception x)
                MessageBox.Show(x.ToString(), "Error");
        }
    }
    
}
