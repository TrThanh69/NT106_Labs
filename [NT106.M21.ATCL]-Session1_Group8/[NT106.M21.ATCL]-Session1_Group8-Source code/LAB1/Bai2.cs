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
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //Tìm
        {
            double num1,num2,num3;
            if (double.TryParse(this.textBox1.Text, out num1) 
                && double.TryParse(this.textBox2.Text, out num2) 
                && double.TryParse(this.textBox3.Text, out num3)) //Kiểm tra đầu vào
            {
                //MAX
                double max;
                if (num1 >= num2 && num1 >= num3)
                {
                    max = num1;
                }
                else if(num2 >= num3 )
                {
                    max = num2;
                }
                else
                {
                    max = num3;
                }
                textBox4.Text = max.ToString();

                //MIN
                double min;
                if (num1 <= num2 && num1 <= num3)
                {
                    min = num1;
                }
                else if (num2 <= num3)
                {
                    min = num2;
                }
                else
                {
                    min = num3;
                }
                textBox5.Text = min.ToString();
            }
            else //Báo lỗi va phải nhập lại
            {
                MessageBox.Show("Bạn đã nhập sai, vui lòng nhập lại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e) //Xóa
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void button3_Click(object sender, EventArgs e) //Thoát
        {
            Application.Exit();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //Kết quả
        }
    }
}
