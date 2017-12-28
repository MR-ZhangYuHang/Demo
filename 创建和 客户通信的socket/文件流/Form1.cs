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

namespace 文件流
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开文件";
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName,FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                textBox2.Text += line;
            }
        }
    }
}
