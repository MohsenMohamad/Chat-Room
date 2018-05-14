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
using persistent_layer.Data_type;

namespace GUI
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        private User userlogin;
        private List<Message> Message_List;


        public Chat(User userlogin)
        {
            InitializeComponent();
            this.userlogin = userlogin;
            Message_List=Business_layer.communication.send_reseve_Massge.recallMessage();

            foreach (Message x in Message_List)
            {
             Label_Messages.Content=(x.grupid + ":" + x.UserName + ":                 " + x.Data)+(Label_Messages.Content);
             
            }
            

        }

        private void update()
        {

        }

        private void Button_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("See you soon!");
            // logout
            Application.Current.Shutdown();

        }
    }
}
