using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;

namespace Bai4
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private string getHTML(string szURL)
        {
            // Create a request for the URL.
            WebRequest request = WebRequest.Create(szURL);
            // Get the response.
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Close the response.
            response.Close();
            return responseFromServer;
        }
        private void button1_Click(object sender, EventArgs e) //Xem nội dung
        {
            webBrowser1.Navigate(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e) //Tải file HTML
        {
            String source = ("viewsource.txt");
            StreamWriter writer = File.CreateText(source);
            writer.Write(webBrowser1.DocumentText);
            writer.Close();
            Process.Start("notepad.exe", source);
        }

        private void button3_Click(object sender, EventArgs e) //Xem Sources
        {
            String source = ("viewsource.txt");
            StreamWriter writer = File.CreateText(source);
            writer.Write(webBrowser1.DocumentText);
            writer.Close();
            Process.Start("notepad.exe", source);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
