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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Login_Screen();
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            Clear_Fields();
            Button_Login.Visibility = Visibility.Visible;
            Login_Screen();
        }

        private void Register_Screen_Click(object sender, RoutedEventArgs e)
        {
            Register_Screen();
        }

        private void Register_Screen()
        {
            Clear_Fields();
            Button_Login.Visibility = Visibility.Hidden;
            Label_ID.Visibility = Visibility.Visible;
            Text_ID.Visibility = Visibility.Visible;
            Button_Back.Visibility = Visibility.Visible;

        }

        private void Login_Screen()
        {
            Label_ID.Visibility = Visibility.Hidden;
            Text_ID.Visibility = Visibility.Hidden;
            Button_Back.Visibility = Visibility.Hidden;
        }

        private void Clear_Fields()
        {
            Text_Name.Text = String.Empty;
            Box_Password.Clear();
            Text_ID.Text = String.Empty;

        }

      
    }
}
