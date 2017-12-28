using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel导入
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Filedate> fds = new List<Filedate>();
        public string AccessFilePath { get; set; }
        public string SQLuid { get; set; }
        public string SQLpwd { get; set; }


        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            fds.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ("Excel 文件(*.xls)|*.xlsx");//后缀名。  
            ofd.Multiselect = true;
            ofd.ShowDialog();
            for (int i = 0; i < ofd.SafeFileNames.Length; i++)
            {
                Filedate fd = new Filedate();
                fd.FileName = ofd.SafeFileNames[i];
                fd.FilePath = ofd.FileNames[i];
                fds.Add(fd);
                listBox1.Items.Add(fd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "ACCESS":
                    ImportAccess();
                    break;
                case "SQL SERVER":
                    ImportSQL();
                    break;
                case "MY SQL":
                    break;
                case "ORACLE":
                    break;
                default:
                    MessageBox.Show("请选择数据库类型");
                    break;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "ACCESS":
                    listBox2.Items.Clear();
                    ACCESS acc = new ACCESS();
                    acc.Owner = this;
                    acc.ShowDialog();
                    GetTableNameAccess();
                    break;
                case "SQL SERVER":
                    listBox2.Items.Clear();
                    comboBox2.Items.Clear();
                    SQLServer sqls = new SQLServer();
                    sqls.Owner = this;
                    sqls.ShowDialog();
                    GetDataBase();
                    break;
                case "MY SQL":
                    break;
                case "ORACLE":
                    break;
                default:
                    break;
            }
        }
        public void ImportAccess()
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("请选择导入数据的EXCEL文件!");
            }
            else if (listBox2.SelectedItem==null)
            {
                MessageBox.Show("请选择导入数据的表名!");
            }
            else
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AccessFilePath + ";Persist Security Info=False;"; //绝对路径
                con.Open();
                StringBuilder strb = new StringBuilder();
                try
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        DataTable dt = ExcelHelper.InputFromExcel(fds[i].FilePath, ExcelHelper.GetExcelTables(fds[i].FilePath)[0].ToString());
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("请检查你的Excel中是否存在数据");
                        }
                        progressBar1.Maximum = dt.Rows.Count;
                        progressBar1.Show();
                        label2.Text = fds[i].FilePath + "导入中......";
                        foreach (DataRow rows in dt.Rows)
                        {
                            strb.Append(" insert into " + listBox2.SelectedItem.ToString() + " ( ");
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                if (j+1==dt.Columns.Count)
                                {
                                strb.Append(dt.Columns[j].ToString()+") values (");
                                }
                                else
                                strb.Append(dt.Columns[j].ToString()+",");
                            }
                            for (int k = 0; k < dt.Columns.Count; k++)
                            {
                                if(k+1==dt.Columns.Count)
                                    strb.Append("'"+rows[k].ToString() + "')");
                                else
                                    strb.Append("'" + rows[k].ToString() + "',");
                            }
                            OleDbCommand com = new OleDbCommand(strb.ToString(), con);
                            com.ExecuteNonQuery();
                            strb.Clear();
                            progressBar1.Value = progressBar1.Value + 1;
                        }
                        progressBar1.Value = 0;
                        label2.Text = "";
                    }
                   
                    MessageBox.Show("导入数据成功");
                    progressBar1.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    progressBar1.Value = 0;
                    label2.Text = "";
                    progressBar1.Hide();
                }
            }
        }
        public void ImportSQL()
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("请选择导入数据的EXCEL文件!");
            }
            else if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("请选择导入数据的表名!");
            }
            else if(comboBox2.SelectedItem==null){
                MessageBox.Show("请选择导入数据的数据库!");
            }
            else
            { 
                StringBuilder strb = new StringBuilder();
                try
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        DataTable dt = ExcelHelper.InputFromExcel(fds[i].FilePath, ExcelHelper.GetExcelTables(fds[i].FilePath)[0].ToString());
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("请检查你的Excel中是否存在数据");
                        }
                        progressBar1.Maximum = listBox1.Items.Count;
                        progressBar1.Show();
                        label2.Text = fds[i].FilePath + "导入中......";
                        strb.Append(" BEGIN TRY ");
                        strb.Append("    SET XACT_ABORT ON ");
                        strb.Append("    BEGIN TRAN ");
                        foreach (DataRow rows in dt.Rows)
                        {
                             strb.Append(" insert into " + listBox2.SelectedItem.ToString() + " ( ");
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                if (j+1==dt.Columns.Count)
                                {
                                strb.Append(dt.Columns[j].ToString()+") values (");
                                }
                                else
                                strb.Append(dt.Columns[j].ToString()+",");
                            }
                            for (int k = 0; k < dt.Columns.Count; k++)
                            {
                                if(k+1==dt.Columns.Count)
                                    strb.Append("'"+rows[k].ToString() + "')");
                                else
                                    strb.Append("'" + rows[k].ToString() + "',");
                            } 
                        }
                        strb.Append("    COMMIT");
                        strb.Append("    SELECT  1");
                        strb.Append(" END TRY");
                        strb.Append(" BEGIN CATCH");
                        strb.Append("    SELECT  0");
                        strb.Append(" END CATCH");
                        SqlHelper.ExecuteDataset("server=.; database=" + comboBox2.SelectedItem + ";pwd=" + SQLpwd + ";uid=" + SQLuid + ";", CommandType.Text, strb.ToString());
                        strb.Clear();
                        progressBar1.Value = progressBar1.Value + 1;
                    }
                    progressBar1.Value = 0;
                    label2.Text = "";
                    MessageBox.Show("导入数据成功");
                    progressBar1.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    progressBar1.Value = 0;
                    label2.Text = "";
                    progressBar1.Hide();
                }
            }
        }
        public void GetTableNameAccess()
        {
            if (AccessFilePath == null)
            {
                MessageBox.Show("请选择Access数据库!");
            }
            else
            {
                List<string> list = new List<string>();
                OleDbConnection Conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AccessFilePath + ";Persist Security Info=False;");
                try
                {
                    if (Conn.State == ConnectionState.Closed)
                        Conn.Open();
                    DataTable dt = Conn.GetSchema("Tables");
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row[3].ToString() == "TABLE")
                        {
                            list.Add(row[2].ToString());
                            listBox2.Items.Add(row[2]);
                        }
                    }
                }
                catch (Exception e)
                { throw e; }
                finally { if (Conn.State == ConnectionState.Open) Conn.Close(); Conn.Dispose(); }
            }
        }
        public void GetDataBase()
        {
            if (SQLuid == null || SQLpwd == null)
            {
                MessageBox.Show("请选择连接类型(ACCESS数据库不用选择此项!)");
            }
            else
            {
                string strConnection = "server=.; database=master;pwd=" + SQLpwd + ";uid=" + SQLuid + ";";
                DataTable dt = SqlHelper.ExecuteDataset(strConnection, CommandType.Text, " select name from master..sysdatabases ").Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    comboBox2.Items.Add(row.ItemArray[0]);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string strConnection = "server=.; database="+comboBox2.SelectedItem+";pwd=" + SQLpwd + ";uid=" + SQLuid + ";";
            DataTable dt = SqlHelper.ExecuteDataset(strConnection, CommandType.Text, " select name from sys.tables ").Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                listBox2.Items.Add(row.ItemArray[0]);
            }
        }
    }
}
