using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 客户端发送信息
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Socket socketsend;
        private void button1_Click(object sender, EventArgs e)
        {
            socketsend = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(textBox3.Text);
            IPEndPoint point = new IPEndPoint(ip, 5000);
            socketsend.Connect(point);
            textBox1.AppendText("连接成功\r\n");
            Thread th = new Thread(SendStr);
            th.IsBackground = true;
            th.Start(socketsend);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox2.Text;
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            socketsend.Send(buffer);
        }
        void SendStr(object o)
        {
            socketsend = o as Socket;
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024 * 5];
                    int r = socketsend.Receive(buffer);
                    if (r == 0)
                    {
                        byte[] buffers = Encoding.UTF8.GetBytes("对方已下线");
                        socketsend.Send(buffers);
                        break;
                    }
                    if (buffer[0]==0)
                    {
                        textBox1.AppendText(socketsend.RemoteEndPoint.ToString() +":"+Encoding.UTF8.GetString(buffer, 0, r-1) + "\r\n");
                    }
                    else if (buffer[0] == 1)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Title = "请选择要保存的文件";
                        sfd.Filter = "所有文件|*.*";
                        sfd.ShowDialog(this);
                        using (FileStream fs=new FileStream(sfd.FileName,FileMode.OpenOrCreate,FileAccess.Write))
                        {
                            fs.Write(buffer,1,r-1);
                        }
                        MessageBox.Show("保存成功");
                    }
                    else if (buffer[0] == 2)
                    {
                        zd();
                    }
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
        void zd()
        {
            for (int i = 0; i < 100; i++)
            {
                this.Location = new Point(200,200);
                this.Location = new Point(220,220);
            }
        }
    }
}
