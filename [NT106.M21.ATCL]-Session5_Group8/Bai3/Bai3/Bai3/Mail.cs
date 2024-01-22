using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace Bai3
{
    
    public partial class Mail : Form
    {
        public Mail()
        {
            InitializeComponent();
        }
        private string email;
        private string password;
        private void Mail_Load(object sender, EventArgs e)
        {

        }
        public Mail(string Email,string Password) : this ()
        {
            email = Email;
            password = Password;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string receiver = textBox2.Text.Trim();
            try
            {
                SmtpClient clientDetails = new SmtpClient();
                clientDetails.Port = 587;
                clientDetails.Host = "smtp.gmail.com";
                clientDetails.EnableSsl = true;
                clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                clientDetails.UseDefaultCredentials = false;
                clientDetails.Credentials = new NetworkCredential(email.ToString(), password.ToString());

                MailMessage mailDetails = new MailMessage();
                mailDetails.From = new MailAddress(email);
                mailDetails.To.Add(receiver);
                mailDetails.Subject = textBox4.Text.Trim();
                mailDetails.IsBodyHtml = true;
                mailDetails.Body = richTextBox1.Text.Trim();

                if (File.Exists(textBox1.Text))
                {
                    Attachment newfile = new Attachment(textBox1.Text);
                    mailDetails.Attachments.Add(newfile);
                }
                clientDetails.Send(mailDetails);
                MessageBox.Show("Email sent!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReadMail readmail = new ReadMail(email, password);
            readmail.Show();
        }
    }
}
