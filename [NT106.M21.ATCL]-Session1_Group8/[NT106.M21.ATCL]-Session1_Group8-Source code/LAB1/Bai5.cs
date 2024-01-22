using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAB1
{
    public partial class Bai5 : Form
    {
        public Bai5()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Nhập A
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Nhập B
        }
        private void button1_Click(object sender, EventArgs e) //Tính
        {
            int A, B;
            if (int.TryParse(this.textBox1.Text, out A)
                && int.TryParse(this.textBox2.Text, out B)) //Kiểm tra số nguyên
            {
                int S1 = 0;
                int S2 = 0;
                double S3 = 0;

                // Giai thừa
                int LA = 1;
                int LB = 1;
                for (int i = 1; i <= A; i++)
                {
                    LA = LA * i;
                }
                for (int i = 1; i <= B; i++)
                {
                    LB = LB * i;
                }

                // Tổng S1 và S2
                for (int i = 1; i <= A; i++)
                {
                    S1 += i;
                }
                for (int i = 1; i <= B; i++)
                {
                    S2 += i;
                }

                // Tổng S3
                for (int i = 1; i <= B; i++)
                {
                    S3 += Math.Pow(A, i);
                }

                listView1.Items.Add("A!= " + LA.ToString() + "\n");
                listView1.Items.Add("B!= " + LB.ToString() + "\n");

                listView1.Items.Add("S1 = 1+2+3+4+...+A = " + S1.ToString() + "\n");
                listView1.Items.Add("S2 = 1+2+3+4+...+A = " + S2.ToString() + "\n");

                listView1.Items.Add("S3 = A^1 + A^2 + A^3 + A^4 +...+ A^B = " + S3.ToString() + "\n");
            }
            else //Sai điều kiện
            {
                MessageBox.Show("Bạn đã nhập sai, vui lòng nhập lại số nguyên !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox1.Clear();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) 
        {
            //Kết quả
        }

        private void button2_Click(object sender, EventArgs e) //Xóa
        {
            textBox1.Clear();
            textBox2.Clear();
            listView1.Clear();
        }

        private void button3_Click(object sender, EventArgs e) //Thoát
        {
            Application.Exit();
        }


    }
}
