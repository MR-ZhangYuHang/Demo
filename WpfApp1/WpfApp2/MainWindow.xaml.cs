using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using WpfApp2.Models;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //List<employee> emp = new List<employee>{
            //    new employee{ID=1,NAME="perter",AGE=140},
            //    new employee{ID=2,NAME="tim",AGE=130},
            //    new employee{ID=11,NAME="tom",AGE=120},
            //    new employee{ID=12,NAME="jack",AGE=110}

            //};
            //this.listbox1.DisplayMemberPath = "NAME";
            //this.listbox1.SelectedValuePath = "ID";
            //this.listbox1.ItemsSource = emp;
            this.gridmain.ColumnDefinitions.Add(new ColumnDefinition());
            this.gridmain.ColumnDefinitions.Add(new ColumnDefinition());
            this.gridmain.ColumnDefinitions.Add(new ColumnDefinition());
            this.gridmain.ColumnDefinitions.Add(new ColumnDefinition());

            this.gridmain.RowDefinitions.Add(new RowDefinition());
            this.gridmain.RowDefinitions.Add(new RowDefinition());
            this.gridmain.RowDefinitions.Add(new RowDefinition());
            this.gridmain.ShowGridLines = true;
        }

    }
}
