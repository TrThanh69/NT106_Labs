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
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//read
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string content = sr.ReadToEnd();
            // Hiện thông tin lên richtextbox
            richTextBox1.Text = content;

            //content = content.Replace("\r\n", ","); //Thay mỗi lần xuống dòng = dấu phẩy

            //string[] pheptinh = content.Split(','); //Tách các phép tính = dấu phẩy 
        }
        public bool IsNumber(string obj)
        {
            if (int.TryParse(obj, out int value)) // Kiểm tra có phải là số nguyên
                return true;
            else return false;
        }
        //calculate
        private void button2_Click(object sender, EventArgs e)
        {
            // Tách từng thông tin trong Box thành từng dòng để xử lý 
            string[] Info = richTextBox1.Text.Trim().Split((new char[] { '\n', '\r' }), StringSplitOptions.RemoveEmptyEntries);
            int i = 0;

            // Tách từng thông tin trong Box thành từng dòng để thêm kết quả 
            string[] Info2 = richTextBox1.Text.Trim().Split((new char[] { '\n', '\r' }), StringSplitOptions.RemoveEmptyEntries);


            foreach (string info in Info)
            {
                float num1 = 0;
                float num2 = 0;
                //lấy từng số trong từng dòng
                if (Info[i].Length == 5)
                {
                    num1 = float.Parse(Info[i].Substring(0, 1)); // Số đầu chuỗi
                    num2 = float.Parse((Info[i].Substring(Info[i].Length - 1, 1))); // Số cuối chuỗi

                }
                else if (Info[i].Length == 6 || Info[i].Length == 7)
                {
                    num1 = float.Parse(Info[i].Substring(0, 2)); // Số đầu chuỗi
                    num2 = float.Parse((Info[i].Substring(Info[i].Length - 2, 2))); // Số cuối chuỗi

                }
                else if (Info[i].Length == 8 || Info[i].Length == 9)
                {
                    num1 = float.Parse(Info[i].Substring(0, 3)); // Số đầu chuỗi
                    num2 = float.Parse((Info[i].Substring(Info[i].Length - 3, 3))); // Số cuối chuỗi

                }
                float result = 0;





                // Kiểm tra xem nếu ko là số nguyên sẽ là dấu
                for (int j = 1; j <= Info[i].Length; j++)
                {

                    if (IsNumber(Info[i].Substring(j - 1, 1)) == false)
                    {
                        string test = Info[i].Substring(j - 1, 1);
                        //richTextBox2.Text += Info[i].Substring(j - 1, 1);
                        switch (test) // dấu
                        {
                            case "/":
                                result = num1 / num2;
                                break;
                            case "-":
                                result = num1 - num2;
                                break;
                            case "+":
                                result = num1 + num2;
                                break;
                            case "*":
                                result = num1 * num2;
                                break;
                            default:
                                break;
                        }

                    }
                }
                //cập nhật kết quả cho từng dòng của output
                Info2[i] = Info2[i] + " = " + result.ToString() + '\n';
                richTextBox2.Text += Info2[i];

                // Important !!
                i++;
            }
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Bai3_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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
    }
}
    
