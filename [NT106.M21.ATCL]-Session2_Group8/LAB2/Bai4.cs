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
using System.Runtime.Serialization.Formatters.Binary;

namespace LAB2
{
    public partial class Bai4 : Form
    {
        public Bai4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Mở file input 
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string context = sr.ReadToEnd();
            // ghi thông tin ra richtextbox
            richTextBox1.Text = context.ToString();
        }
        // Tính toán
        private void button3_Click(object sender, EventArgs e)
        {
            string content = richTextBox1.Text;
            string[] StudentInfo = content.Trim().Split(' '); // từng thông tin cách nhau tạo thành 1 chuỗi dài
            int i = 0;
            content = "";
            float tb = 0;
            foreach (string Info in StudentInfo)
            {
                string diemso = Info.Substring(Info.Length - 7); //Lấy 7 kí tự cuối của chuỗi
                string[] diem = diemso.Split('\n'); //Tách thành 2 số phải xuống dòng

                //Tính điểm trung bình 
                tb = ((float.Parse(diem[0]) + float.Parse(diem[1])) / 2);
            }
            richTextBox2.Text = richTextBox1.Text + "\n" + (float)tb;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // tạo file ouput
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate);
            // Tạo binary formatter để chuyển đổi thông tin thành kiểu dữ liệu ghi được vào stream
            BinaryFormatter bf = new BinaryFormatter();

            // Tách thông tin của từng sinh viên 
            // 1) tách thông tin thành từng string qua từng lần xuống dòng 
            string[] StudentInfo = richTextBox2.Text.Trim().Split((new char[] { '\n', '\r' }), StringSplitOptions.RemoveEmptyEntries);
            // 2) Tách từng thông tin của sinh viên và ghi nội dung vào stream sử dụng Serialize
            string data = string.Empty;
            int i = 0;
            foreach (string Info in StudentInfo)
            {
                // richTextBox2.Text += Info;
                data += (StudentInfo[i] + "\n"); // Đẩy từng thông tin vào data cách nhau bởi '\n'
                i++;
            }
            bf.Serialize(fs, data.Trim(' ', '\n'));
            // 3) Đóng stream 
            fs.Close();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
