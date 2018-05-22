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
            //loging the activety of the project 
            logging_activety.logging_msg("rejester botton activate ");

            //loging the activety of the project 
            logging_activety.logging_msg("take the user and the password from the text box for rejester");
            String name = Text_Name.Text;
            String password = Box_Password.Password;
            String Id_tmp = Text_ID.Text;
            int id = Convert.ToInt32(Id_tmp);
            
            User user = new User(name, id, password);
            //loging the activety of the project 
            logging_activety.logging_msg("new instense of register");
            register temp = new register();

            //loging the activety of the project 
            logging_activety.logging_msg("check if the user is in the data base");

            User newuser = temp.newRegister(user);

            if (newuser == null)
            {
                //loging the activety of the project 
                logging_activety.logging_msg("user is already registered");
                MessageBox.Show(" User is already registered , please try to login instead or register with different info!");
            }
            else {
                //loging the activety of the project 
                logging_activety.logging_msg("new user |add to data base");
                MessageBox.Show(" Done , Welcome to the family :)");
                Clear_Fields();
                Login_Screen();
                Button_Register.Visibility = Visibility.Hidden;
                Button_Login.Visibility = Visibility.Visible;


                }
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            //loging the activety of the project 
            logging_activety.logging_msg("button_login activate ");
            //loging the activety of the project 
            logging_activety.logging_msg("login attembt");
            String name = Text_Name.Text;
            String password = Box_Password.Password;
            //loging the activety of the project 
            logging_activety.logging_msg("new login instens");
            login temp = new login();
            //loging the activety of the project 
            logging_activety.logging_msg("check user in the data base");
            User user = temp.Login(name, password);
            
           
            if (user == null)
            {
                //loging the activety of the project 
                logging_activety.logging_msg("user is not in the data base|show message to the -user not found-");
                MessageBox.Show("User not found!");
            }
            else
            {
                //loging the activety of the project 
                logging_activety.logging_msg("user found | enter to login window");
                Chat chatroom = new Chat(user);
                this.Close();
                chatroom.Show();
            }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            //loging the activety of the project 
            logging_activety.logging_msg("back button activat");
            Clear_Fields();
            //loging the activety of the project 
            logging_activety.logging_msg("return to singin window");
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
            //loging the activety of the project 
            logging_activety.logging_msg("Exit from window ");
            this.Close();
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
}
