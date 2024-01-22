using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAB1
{
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)// Đọc
        {
            int num = 0;
            string text = "";
            if (int.TryParse(this.textBox1.Text, out num) && (num >= 0 && num <= 9))// Kiểm tra dạng dữ liệu và khoảng của nó có thuộc {0;9}
            {
                    switch (num)
                    {
                        case 0:
                            text = "Không";
                            break;
                        case 1:
                            text = "Một";
                            break;
                        case 2:
                            text = "Hai";
                            break;
                        case 3:
                            text = "Ba";
                            break;
                        case 4:
                            text = "Bốn";
                            break;
                        case 5:
                            text = "Năm";
                            break;
                        case 6:
                            text = "Sáu";
                            break;
                        case 7:
                            text = "Bảy";
                            break;
                        case 8:
                            text = "Tám";
                            break;
                        case 9:
                            text = "Chín";
                            break;
                    }
                    textBox4.Text = text;
            }
            else // báo lỗi và phải nhập lại
            {
                MessageBox.Show("Bạn đã nhập sai, vui lòng nhập lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)// Xóa
        {
            textBox1.Clear();
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)// Thoát
        {
            Application.Exit();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //Kết quả
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Nhập
        }
    }
}
