using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;


namespace Bai1
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
                SmtpClient clientDetails = new SmtpClient();
                clientDetails.Port = Convert.ToInt32(587.ToString());
                clientDetails.Host = "smtp.gmail.com";
                clientDetails.EnableSsl = true;
                clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                clientDetails.UseDefaultCredentials = false;
                clientDetails.Credentials = new NetworkCredential(textBox1.Text.Trim(), textBox3.Text.Trim());

                MailMessage mailDetails = new MailMessage();
                mailDetails.From = new MailAddress(textBox1.Text.Trim());
                mailDetails.To.Add(textBox2.Text.Trim());
                mailDetails.Subject = textBox4.Text.Trim();
                mailDetails.IsBodyHtml = true;
                mailDetails.Body = richTextBox1.Text.Trim();

                
                clientDetails.Send(mailDetails);
                MessageBox.Show("Email sent!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
