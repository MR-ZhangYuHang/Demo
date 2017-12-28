using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel导入
{
    public partial class ACCESS : Form
    {
        public ACCESS()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ("Excel 文件(*.accdb)|*.accdb");//后缀名。  
            ofd.ShowDialog();
            textBox1.Text = ofd.FileName.ToString();

            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指针赋给lForm1
            lForm1.AccessFilePath = ofd.FileName.ToString(); //使用父窗口指针赋值
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 acc = new Form1();
            acc.Owner = this;
            this.Close();
        }
    }
}
