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
namespace Bai1_Lap03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //listView1.Items.Add('')
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
        }
        void StartUnsafeThread()
        {
            int bytesReceived = 0;
            // khoi tao mang byte nhan giu lieu 
            byte[] recv = new byte[1];
            // tao socket ben gui
            Socket clientSocket;
            // Tạo socket lắng nghe tới các kết nối tới địa chỉ IP và port 8080  ở bên nhận 
            // Address family: trả về họ địa chỉ IP hiện hành, hiện là Iv4 => AddressFamily.InterNetwork
            // Sử dụng luồng stream để nhận giữ liệu 
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            // Gán socket lắng nghe tới địa chỉ IP của máy và port 
            listenerSocket.Bind(ipepServer);
            // bắt đầu lắng nghe 
            //Socket.Listen(int backlog);

            listenerSocket.Listen(-1);
            // Đồng ý kết nối 
            clientSocket = listenerSocket.Accept();
            // nhận dữ liệu 
            listView1.Items.Add(new ListViewItem("New client connected"));
            while(clientSocket.Connected)
            {
                string text = "";
                do
                {
                    bytesReceived = clientSocket.Receive(recv);
                    text += Encoding.UTF8.GetString(recv);
                } while (text[text.Length - 1] != '\n');
                listView1.Items.Add(new ListViewItem(text));
            }
            listenerSocket.Close();

        }
    }
}
