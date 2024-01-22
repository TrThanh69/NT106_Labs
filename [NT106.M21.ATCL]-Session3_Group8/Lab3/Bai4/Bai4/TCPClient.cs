using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Bai4
{
    public partial class TCPClient : Form
    {

        TcpClient tcpClient = new TcpClient();
        public Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public IPEndPoint ipepServer = new IPEndPoint(IPAddress.Any, 8080);
        NetworkStream network = default(NetworkStream);
        string readData = null;

        public TCPClient()
        {
            InitializeComponent();
        }

        private void TCPClient_Load_1(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint iPEndPoint = new IPEndPoint(ipAddress, 8080);
            try
            {
                tcpClient.Connect(iPEndPoint);
                richTextBox1.Text += "Bạn đã vào Server thành công." + '\n';
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            Thread threading = new Thread(GetMessager);
            threading.IsBackground = true;
            threading.Start();
        }

        private void messager()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(messager));
            }
            else
            {
                richTextBox1.Text += readData;
            }
        }

        private void GetMessager()
        {
            string returnData;
            try
            {
                while (true)
                {
                    network = tcpClient.GetStream();
                    var buffSize = tcpClient.ReceiveBufferSize;
                    byte[] data = new byte[buffSize];
                    network.Read(data, 0, buffSize);
                    returnData = Encoding.UTF8.GetString(data);
                    readData = returnData;
                    messager();
                }
            }
            catch
            {
                tcpClient.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e) //Send
        {
            if (richTextBox2.Text != string.Empty)
            {
                if (textBox1.Text != string.Empty)
                {
                    string mess = textBox1.Text + " : " + richTextBox2.Text + '\n';
                    Byte[] data = Encoding.UTF8.GetBytes(mess);
                    network.Write(data, 0, data.Length);
                    richTextBox1.Text += mess;
                    richTextBox2.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Hãy nhập Tên người dùng !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TCPClient_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
