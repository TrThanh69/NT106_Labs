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
    public partial class TCPServer : Form
    {
        public TCPServer()
        {
            InitializeComponent();
        }
        public List<Socket> clientList;
        IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
        Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private void button1_Click(object sender, EventArgs e) // Listener
        {
            listenerSocket.Bind(ipepServer);
            listenerSocket.Listen(-1);
            CheckForIllegalCrossThreadCalls = false;
            for (int i = 0; i <= 100; i++)
            {
                Thread serverThread = new Thread(new ThreadStart(Listener));
                serverThread.Start();
            }
            button1.Enabled = false;

        }
        void Listener()
        {
            int bytesReceived = 1;
            byte[] recv = new byte[1];
            clientList = new List<Socket>();
            Socket clientSocket = listenerSocket.Accept();
            clientList.Add(clientSocket);
            var endPoint = (IPEndPoint)clientSocket.RemoteEndPoint;
            string newClient = "New client connected from : " + endPoint + '\n';
            richTextBox1.Text += newClient;
            try
            {
                while (clientSocket.Connected && bytesReceived == 1)
                {
                    string text = "";
                    do
                    {
                        bytesReceived = clientSocket.Receive(recv);
                        text += Encoding.UTF8.GetString(recv);

                    } while (text[text.Length - 1] != '\n' && bytesReceived == 1);
                    richTextBox1.Text += text;
                    sendMess(text, clientSocket);
                }
            }
            catch
            {
                clientList.Remove(clientSocket);
                listenerSocket.Close();
                richTextBox1.Text += "A client" + endPoint + "disconnected";
            }

        }
        void sendMess(string s, Socket client)
        {
            foreach (Socket item in clientList)
            {
                if (item != null && item != client)
                    item.Send(Encoding.UTF8.GetBytes(s));
            }
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
