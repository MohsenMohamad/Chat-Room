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
using Business_layer;
using Business_layer.Login_out;
using persistent_layer.Data_type;
using System.Text.RegularExpressions;


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
             
            logging_activety.logging_msg("register botton activate "); // Log
            String name = Text_Name.Text;
            String password = Box_Password.Password;
            String Id = Text_ID.Text;
            int id = 0;
            if(!Legal_ID(Id) || !Legal_Password(password))
                    return;

            User user = new User(name, id, password);
            logging_activety.logging_msg("new instense of register"); // Log
            register temp = new register();

            logging_activety.logging_msg("check if the user is in the data base"); // Log
            User newuser = temp.newRegister(user);

            if (newuser == null)
            { 
                logging_activety.logging_msg("user is already registered"); // Log
                MessageBox.Show(" User is already registered , please try to login instead or register with different info!");
            }
            else {
                    logging_activety.logging_msg("new user |add to data base"); // Log
                    MessageBox.Show(" Done , Welcome to the family :)");
                    Clear_Fields();
                    Login_Screen();
                    Button_Register.Visibility = Visibility.Hidden;
                    Button_Login.Visibility = Visibility.Visible;


                }
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
             
            logging_activety.logging_msg("login attempt"); // Log
            String name = Text_Name.Text;
            String password = Box_Password.Password;
            login temp = new login();
            logging_activety.logging_msg("check user in the data base"); // Log
            User user = temp.Login(name, password);
           
            if (user == null)
            {
                logging_activety.logging_msg("user is not in the data base"); // Log
                MessageBox.Show("User not found!");
            }
            else
            { 
                logging_activety.logging_msg("user found | enter to login window"); // Log
                Chat chatroom = new Chat(user);
                this.Close();
                chatroom.Show();
            }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            Clear_Fields(); 
            logging_activety.logging_msg("User returned to Log-in window"); // Log
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
            logging_activety.logging_msg("App closed"); // Log
            this.Close();
        }


        private bool Legal_Password(String password)
        {
            if (password!=null && ( password.Length < 4 || password.Length > 16 || !Regex.IsMatch(password, @"^[a-zA-Z0-9]+$")))
            {
                MessageBox.Show("Illegal Password");
                return false;
            }

            return true;
        }


        // checks if the id input is a positive integer
        private bool Legal_ID(String id)
        {
            try
            {
                return Convert.ToInt32(id)>0;
            }
            catch
            {
                MessageBox.Show("Illegal ID!");
                return false;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
