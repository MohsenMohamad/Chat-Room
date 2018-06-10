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
        
        // Checks if all the required info for registeration is legal
        // Register the User if and only if every field is legal.
        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            logging_activety.logging_msg("Registeration attempt"); // Log
            register temp = new register();
            String name = Text_Name.Text;
            String password = Box_Password.Password;
            String Id = Text_ID.Text;
            int id = 0;

            if (!Legal_ID(Id) || !Legal_Name(name) ||!Legal_Password(password))
                return;

            id = Convert.ToInt32(Id);
            bool successfull = temp.newRegister(name,password,Id);

            if (!successfull)
                MessageBox.Show(" User is already registered , please try to login instead or register with different info!");
            
            else {
                    MessageBox.Show(" Done , Welcome to the family :)");
                    Clear_Fields();
                    Login_Screen();
                    Button_Register.Visibility = Visibility.Hidden;
                    Button_Login.Visibility = Visibility.Visible;

                }
        }

        // If the User info are correct open a new chat window
        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
             
            String name = Text_Name.Text;
            String password = Box_Password.Password;
            String groupID = Text_ID.Text;
            login temp = new login();
            // may add an if statement that checks if the inputs are all legal
            User user = temp.Login( name, password , groupID );
           
            if (user == null)
                MessageBox.Show("User not found!");
            
            else
            { 
                Chat chatroom = new Chat(user);
                this.Close();
                chatroom.Show();
            }
        }

        // Cancels the registeration and sends the User back to the Log-in Screen.
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            Clear_Fields(); 
            logging_activety.logging_msg("User returned to Log-in window"); // Log
            Button_Login.Visibility = Visibility.Visible;
            Login_Screen();
        }

        //
        private void Register_Screen_Click(object sender, RoutedEventArgs e)
        {
            logging_activety.logging_msg("User moved to the registeration screen"); // Log
            Register_Screen();
        }

        //
        private void Register_Screen()
        {

            Clear_Fields();
            Button_Register.Visibility = Visibility.Visible;
            Button_Login.Visibility = Visibility.Hidden;
            Button_registerScreen.Visibility = Visibility.Hidden;
     //       Label_ID.Visibility = Visibility.Visible;
    //        Text_ID.Visibility = Visibility.Visible;
            Button_Back.Visibility = Visibility.Visible;

        }

        //
        private void Login_Screen()
        {
            Button_registerScreen.Visibility = Visibility.Visible;
    //      Label_ID.Visibility = Visibility.Hidden;
    //      Text_ID.Visibility = Visibility.Hidden;
            Button_Back.Visibility = Visibility.Hidden;
        }

        //
        private void Clear_Fields()
        {
            Text_Name.Text = String.Empty;
            Box_Password.Clear();
            Text_ID.Text = String.Empty;

        }

        //
        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            logging_activety.logging_msg("App closed"); // Log
            this.Close();
        }

        //
        private bool Legal_Password(String password)
        {
            if (password!=null && ( password.Length < 4 || password.Length > 16 || !Regex.IsMatch(password, @"^[a-zA-Z0-9]+$")))
            {
                logging_activety.logging_msg("Registeration Failed! , Illegal Password "); // Log
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
                logging_activety.logging_msg("Registeration Failed! , Illegal ID "); // Log
                MessageBox.Show("Illegal ID!");
                return false;
            }
        }

        private bool Legal_Name(String name)
        {
            if(name==null || name.Length > 10)
            {
                logging_activety.logging_msg("Registeration Failed! , Illegal Name "); // Log
                MessageBox.Show("Illegal Name!");
                return false;
            }
            return true;
        }

        //
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)

        {

        //    PasswordBox pb = sender as PasswordBox;
        //      MessageBox.Show(pb.Password);

        }

        //
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
