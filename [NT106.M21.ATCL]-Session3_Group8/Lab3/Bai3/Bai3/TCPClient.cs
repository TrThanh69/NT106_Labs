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


namespace Bai3
{
    public partial class TCPClient : Form
    {
        private TcpClient client;
        private NetworkStream stream;

        public TCPClient()
        {
            InitializeComponent();
            client = new TcpClient();
            IPAddress ipAddess = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddess, 8080);
            client.Connect(ipEndPoint);
            stream = client.GetStream();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("Hello Server\n");
            stream.Write(data, 0, data.Length);
        }
        ~TCPClient()
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("Quit\n");
            stream.Write(data, 0, data.Length);
            stream.Close();
            client.Close();
        }
        private void TCPClient_Load(object sender, EventArgs e)
        {
            
        }
    }
}
