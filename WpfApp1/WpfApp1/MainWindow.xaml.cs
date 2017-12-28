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
using System.Data.SqlClient;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Binding binding = new Binding("Value");
            //binding.Source = this.slider;
            //binding.Mode = BindingMode.TwoWay;
            //binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //this.textbox1.SetBinding(TextBox.TextProperty, binding);


            //check1.IsThreeState = true;
            //Binding binding = new Binding("Text");
            //binding.Source = this.textbox1;
            //binding.Converter = new ConverterYN2TF();
            //this.check1.SetBinding(CheckBox.IsCheckedProperty,binding);

            //Binding bining = new Binding("Value");
            //bining.Source = this.slider;
            //bining.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //bining.ValidationRules.Add(new MyValidationRule());
            //textbox1.SetBinding(TextBox.TextProperty, bining);

            //List<Student> stulist = new List<Student>()
            //{
            //    new Student{StuNum=1, Name="Tim", Age=28},
            //    new Student{StuNum=2, Name="Ma Guo", Age=25},
            //    new Student{StuNum=3, Name="Yan", Age=25},
            //    new Student{StuNum=4, Name="Xaiochen", Age=28},
            //    new Student{StuNum=5, Name="Miao miao", Age=24},
            //    new Student{StuNum=6, Name="Ma Zhen", Age=24} 
            //};
            //this.listbox1.ItemsSource = stulist;
            //this.listbox1.DisplayMemberPath = "Name";
            //this.listbox1.SelectedValuePath = "StuNum";
            //this.textbox3.SetBinding(TextBox.TextProperty, new Binding("SelectedItem.StuNum") { Source = this.listbox1 });
            //this.textbox4.SetBinding(TextBox.TextProperty, new Binding("SelectedItem.Name") { Source = this.listbox1 });
            //this.textbox5.SetBinding(TextBox.TextProperty, new Binding("SelectedItem.Age") { Source = this.listbox1 });

            //List<Student> stuList = new List<Student>() 
            //{
            //    new Student{ID=1, Name="Tim", Age=28},
            //    new Student{ID=2, Name="Ma Guo", Age=25},
            //    new Student{ID=3, Name="Yan", Age=25},
            //};
            //        List<Teacher> tchrList = new List<Teacher>()
            //{
            //    new Teacher{ID=1, Name="Ma Zhen", Age=24},
            //    new Teacher{ID=2, Name="Miao miao", Age=24},
            //    new Teacher{ID=3, Name="Allen", Age=26}
            //};
            //        this.listbox1.ItemsSource = stuList;
            //        this.listbox2.ItemsSource = tchrList;
            //        this.listbox1.DisplayMemberPath = "Name";
            //        this.listbox2.DisplayMemberPath = "Name";
            //        listbox1.SelectionChanged += (sender, e) => { this.DataContext = this.listbox1.SelectedItem; };
            //        listbox2.SelectionChanged += (sender, e) => { this.DataContext = this.listbox2.SelectedItem; };
            //        this.textbox3.SetBinding(TextBox.TextProperty, new Binding("ID"));
            //        this.textbox4.SetBinding(TextBox.TextProperty, new Binding("Name"));
            //        this.textbox5.SetBinding(TextBox.TextProperty, new Binding("Age")); 

            Binding b1 = new Binding("Text") { Source=this.textbox1};
            Binding b2 = new Binding("Text") { Source = this.textbox2 };
            Binding b3 = new Binding("Text") { Source = this.textbox3 };
            Binding b4 = new Binding("Text") { Source = this.textbox4 };
            Binding b5 = new Binding("Text") { Source = this.textbox5 };
            MultiBinding mb = new MultiBinding();
            mb.Bindings.Add(b1);
            mb.Bindings.Add(b2);
            mb.Bindings.Add(b3);
            mb.Bindings.Add(b4);
            mb.Bindings.Add(b5);
            mb.Converter = new SubmitEnableConverter();
            mb.Mode = BindingMode.OneWay;
            this.btn1.SetBinding(Button.IsEnabledProperty,mb);
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
