using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAB1
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)// Tính 
        {
            int num1, num2;
            long sum = 0;
            if (int.TryParse(this.textBox1.Text, out num1) 
                && int.TryParse(this.textBox2.Text, out num2)) //Kiểm tra có phải số nguyên ?
            {
                num1 = Int32.Parse(textBox1.Text.Trim());
                num2 = Int32.Parse(textBox2.Text.Trim());
                MessageBox.Show("Bạn đã nhập đúng !", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sum = num1 + num2;//Tính Tổng 2 số
                textBox3.Text = sum.ToString();
            }
            else //Báo lỗi khi nhập sai điều kiện
            {
                MessageBox.Show("Bạn đã nhập sai, vui lòng nhập lại số nguyên !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Clear();
                textBox2.Clear();
                textBox1.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Nhập số thứ hai
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Nhập số thứ nhất
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Kết quả
        }
    }
}
