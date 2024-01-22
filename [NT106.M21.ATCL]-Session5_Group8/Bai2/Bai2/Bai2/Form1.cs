using System;
using System.Windows.Forms;
using MailKit.Net.Imap;
using MailKit.Security;
using MailKit;


namespace Bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var client = new ImapClient())
            {
                try
                {
                    client.CheckCertificateRevocation = false;
                    client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
                    client.Authenticate(textBox1.Text.Trim(), textBox2.Text.Trim());
                    MessageBox.Show("Đăng nhập thành công");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);
                label4.Text = inbox.Count.ToString();
                label6.Text = inbox.Recent.ToString();
                listView1.Columns.Add("Email", 200);
                listView1.Columns.Add("From", 100);
                listView1.Columns.Add("Thời gian", 100);
                listView1.View = View.Details;
                for (int i = 0; i < inbox.Count; i++)
                {
                    var message = inbox.GetMessage(i);
                    ListViewItem name = new ListViewItem(message.Subject);
                    ListViewItem.ListViewSubItem from = new
                    ListViewItem.ListViewSubItem(name, message.From.ToString());
                    name.SubItems.Add(from);
                    ListViewItem.ListViewSubItem date = new
                    ListViewItem.ListViewSubItem(name, message.Date.Date.ToString());
                    name.SubItems.Add(date);
                    listView1.Items.Add(name);
                }

                client.Disconnect(true);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
