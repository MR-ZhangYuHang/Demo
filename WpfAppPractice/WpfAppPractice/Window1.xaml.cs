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
using System.Windows.Shapes;

namespace WpfAppPractice
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Dosomething(object sender, RoutedEventArgs e)
        {
            if (sender==abc)
            {
                MessageBox.Show("success"); 
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("anjian");
        }

        private void PasswordBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.Key.ToString()+e.RoutedEvent);
        }

        private void PasswordBox_TextInput(object sender, TextCompositionEventArgs e)
        {
            MessageBox.Show("textjian");
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            SolidColorBrush brush=new SolidColorBrush(Colors.LightBlue);
            sp.Background = brush;
        }

        private void sp_MouseLeave(object sender, MouseEventArgs e)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.White);
            sp.Background = brush;
        }

        private void ab_MouseEnter(object sender, MouseEventArgs e)
        {
            ab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6bdddb"));
        }

        private void ab_MouseLeave(object sender, MouseEventArgs e)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.White);
            ab.Background = brush;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("11111");
        }
        int i = 0;
        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            btext.Text = (i+1).ToString();
        }
    }
}
