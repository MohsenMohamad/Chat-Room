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
using Business_layer.Login_out;
using persistent_layer.Data_type;

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
            String name = Text_Name.Text;
            String password = Box_Password.Password;
            String Id_tmp = Text_ID.Text;
            int id = Convert.ToInt32(Id_tmp);
            
            User user = new User(name, id, password);
            register temp = new register();
            User newuser = temp.newRegister(user);

            if (newuser == null)
            {
                MessageBox.Show(" User is already registered , please try to login instead or register with different info!");
            }
            else { 
                MessageBox.Show(" Done , Welcome to the family :)");
                Clear_Fields();
                Login_Screen();
                Button_Register.Visibility = Visibility.Hidden;
                Button_Login.Visibility = Visibility.Visible;


                }
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            String name = Text_Name.Text;
            String password = Box_Password.Password;
            login temp = new login();
            User user = temp.Login(name, password);
            
           
            if (user == null)
            {
                MessageBox.Show("User not found!");
            }
            else
            {
                Chat chatroom = new Chat(user);
                this.Close();
                chatroom.Show();
            }
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
            Button_Register.Visibility = Visibility.Visible;
            Button_Login.Visibility = Visibility.Hidden;
            Button_registerScreen.Visibility = Visibility.Hidden;
            Label_ID.Visibility = Visibility.Visible;
            Text_ID.Visibility = Visibility.Visible;
            Button_Back.Visibility = Visibility.Visible;

        }

        private void Login_Screen()
        {
            Button_registerScreen.Visibility = Visibility.Visible;
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

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
}
