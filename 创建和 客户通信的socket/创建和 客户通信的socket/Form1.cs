using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
namespace 创建和_客户通信的socket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Socket socketsend;
        Dictionary<string, Socket> dicsocket = new Dictionary<string, Socket>();
        private void button1_Click(object sender, EventArgs e)
        {
            Socket socketwatch = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            IPAddress ip = IPAddress.Any;
            IPEndPoint point = new IPEndPoint(ip,5000);
            socketwatch.Bind(point);
            textBox1.AppendText("监听成功\r\n");
            socketwatch.Listen(10);
            Thread th = new Thread(Listen);
            th.IsBackground = true;
            th.Start(socketwatch);
        }
        void Listen(object o)
        {
            Socket socketwatch = o as Socket;
            while (true)
            {
                try
                {
                    socketsend = socketwatch.Accept();
                    textBox1.AppendText(socketsend.RemoteEndPoint.ToString() + ":连接成功\r\n");
                    comboBox1.Items.Add(socketsend.RemoteEndPoint.ToString());
                    dicsocket.Add(socketsend.RemoteEndPoint.ToString(),socketsend);
                    Thread th = new Thread(SendStr);
                    th.IsBackground = true;
                    th.Start(socketsend);
                }
                catch 
                {
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        void SendStr(object o)
        {
             socketsend = o as Socket;
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024 * 2];
                    int r = socketsend.Receive(buffer);
                    if (r == 0)
                    {
                        break;
                    }
                    textBox1.AppendText(socketsend.RemoteEndPoint.ToString()+":"+Encoding.UTF8.GetString(buffer, 0, r) + "\r\n");
                }
                catch 
                {
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox2.Text;
            byte [] buffer =Encoding.UTF8.GetBytes(str);
            List<byte> list = new List<byte>();
            list.Add(0);
            list.AddRange(buffer);
            byte[] newbuffer = list.ToArray();
            string id = comboBox1.SelectedItem.ToString();
            dicsocket[id].Send(newbuffer);
            //socketsend.Send(buffer);
        }
        /// <summary>
        /// 选择发送的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择要发送的文件";
            ofd.Filter = "所有文件|*.*";
            ofd.ShowDialog();
            textBox3.Text = ofd.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (FileStream fs=new FileStream(textBox3.Text,FileMode.Open,FileAccess.Read))
            {
                byte[] buffer = new byte[1024 * 1024 * 5];
                int r = fs.Read(buffer, 0, buffer.Length);
                List<byte> list = new List<byte>();
                list.Add(1);    
                list.AddRange(buffer);
                byte[] newbuffer = list.ToArray();
                dicsocket[comboBox1.SelectedItem.ToString()].Send(newbuffer,0,r+1,SocketFlags.None);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[1];
            buffer[0] = 2;
            dicsocket[comboBox1.SelectedItem.ToString()].Send(buffer);
        }
    }
}
