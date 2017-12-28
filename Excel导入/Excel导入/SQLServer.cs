using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Excel导入
{
    public partial class SQLServer : Form
    {
        public SQLServer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uid=textBox1.Text;
            string pwd=textBox2.Text;
            string strConnection = "server=.; database=master;pwd=" + pwd + ";uid=" + uid + ";";
            bool CanConnectDB = false;
            using (SqlConnection objConnection = new SqlConnection(strConnection))
            {
                try
                {
                    objConnection.Open();
                    CanConnectDB = true;
                    objConnection.Close();
                }
                catch { }
                if (CanConnectDB){
                    MessageBox.Show("数据库连接成功！");
                    Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指针赋给lForm1
                    lForm1.SQLpwd = pwd;//使用父窗口指针赋值
                    lForm1.SQLuid = uid;//使用父窗口指针赋值
                    this.Close();
                }
                else MessageBox.Show("数据库连接失败！");
            }
        }
    }
}
