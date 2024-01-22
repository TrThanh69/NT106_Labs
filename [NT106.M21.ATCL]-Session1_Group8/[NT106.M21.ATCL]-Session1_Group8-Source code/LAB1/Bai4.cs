using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace LAB1
{
    public partial class Bai4 : Form
    {
        public Bai4()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            /*
              Hiển thị tỉ lệ quy đổi như sau:
                1 USD = 22,772 VNĐ
                1 EUR = 28,132 VNĐ
                1 GBP = 31,538 VNĐ
                1 SGD = 17,286 VNĐ
                1 JPY = 214 VNĐ
             */
        }

        private void Bai4_Load(object sender, EventArgs e) //Tạo Combo với nhiều sự lựa chọn
        {
            string[] tiente = new string[] { "USD", "EUR", "GBP", "SGD", "JPY" };
            comboBox1.Items.AddRange(tiente);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Nhập số tiền
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Số tiền quy đổi
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Lựa chọn tỉ giá
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num;
            if (double.TryParse(this.textBox1.Text, out num))// Kiểm tra đầu vao
                {
                if (comboBox1.Text.Equals("USD"))//tương ứng với từng tùy chọn "USD" trong comboBox1
                {
                    num = num * 22.772;
                    textBox4.Text = "1 USD = 22,772 VNĐ";
                }
                else if (comboBox1.Text.Equals("EUR"))//tương ứng với từng tùy chọn "EUR" trong comboBox1
                {
                    num = num * 28.132;
                    textBox4.Text = "1 EUR = 28,132 VNĐ";
                }
                else if (comboBox1.Text.Equals("GBP"))//tương ứng với từng tùy chọn "GBP" trong comboBox1
                {
                    num = num * 31.538;
                    textBox4.Text = "1 GBP = 31,538 VNĐ";
                }
                else if (comboBox1.Text.Equals("SGD"))//tương ứng với từng tùy chọn "SGD" trong comboBox1
                {
                    num = num * 17.286;
                    textBox4.Text = "1 SGD = 17,286 VNĐ";
                }
                else if (comboBox1.Text.Equals("JPY"))//tương ứng với từng tùy chọn "JPY" trong comboBox1
                {
                    num = num * 214;
                    textBox4.Text = "1 JPY = 214 VNĐ";
                }
                textBox2.Text = num.ToString();//In ra kết quả
            }
            else
            {
                MessageBox.Show("Bạn đã nhập sai, vui lòng nhập lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
            }
        }
    }
}
