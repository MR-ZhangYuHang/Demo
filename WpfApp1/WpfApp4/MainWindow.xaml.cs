using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace WpfApp4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBind_Click(object sender, RoutedEventArgs e)
        {
            //List<Sorce> ds = new List<Sorce>();
            //for (int i = 0; i < 10; i++)
            //{
            //    var d1 = new Sorce()
            //    {
            //       PerformanceStatus="理论考试"+i,
            //       CommitTime=Convert.ToDateTime("2017-4-1"),
            //       Achievement = 100
            //    };
            //    ds.Add(d1);
            //}
            //this.gridList.ItemsSource = ds;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=.;database=stuDB;uid=sa;pwd=sa123;";
            conn.Open();
            string sql = "select * from sorce";
            SqlCommand comm = new SqlCommand(sql, conn);
            DataTable dt = new DataTable();
            
            //SqlParameter sp = new SqlParameter("@id", id);
            //comm.Parameters.Add(sp);
            SqlDataReader sdr = comm.ExecuteReader();
            dt.Load(sdr);
            this.gridList.ItemsSource = dt.DefaultView;
            sdr.Close();
            conn.Close();
        }
        public class Sorce
        {
            public string PerformanceStatus{get;set;}
            public DateTime CommitTime{get;set;}
            public int Achievement { get; set; }
        }
    }
}
