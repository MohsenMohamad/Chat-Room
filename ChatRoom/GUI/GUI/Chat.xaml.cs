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
using Business_layer.Login_out;
using Business_layer;
using persistent_layer.Data_type;
using Business_layer.communication;
using Business_layer.Filter_sort;
using System.Windows.Threading;

namespace GUI
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        private User userlogin;
        ObservableObject _main = new ObservableObject();
        DateTime time = DateTime.Now;
        private List<Message> Message_List;
        private List<Message> Filtered_Message_List;
        DispatcherTimer timer = new DispatcherTimer();

        //Creates the windows' display
        public Chat(User userlogin)
        {

            this.DataContext = _main;
            this.userlogin = userlogin;
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Button_Filter_Sort_Click;/*update;*/
            timer.Start();
            
        }
        
        //updates the 
        private void update(List<Message> Message_List)
        {

            //Message_List = Business_layer.communication.send_reseve_Massge.recallMessage();
            // updates the Filtered_Message_List using current filter and sort , so that the textblock text will be binded to it
            _main.Messages.Clear(); 
            logging_activety.logging_msg("Updating the interface..."); // Log
            foreach (Message x in Message_List)
            {
                {
                    _main.Messages.Add((String)("id:" + x.getGroupID() + "  " + x.getSender() + ":  " + x.getContent() + "   Time:" + x.getTime() ));
                    
                    if (!(Combo_Id.Items.Contains(x.getGroupID())))
                    {
                        Combo_Id.Items.Add(x.getGroupID());
                    }
                    if (!(Combo_User.Items.Contains("<" + x.getGroupID() + "," + x.getSender() + ">")))
                    {
                        Combo_User.Items.Add("<" + x.getGroupID() + "," + x.getSender() + ">");
                    }
                }
            }
           
        }

        // Closes the chat window and opens a main window
        private void Button_Logout_Click(object sender, RoutedEventArgs e)
        {
            logging_activety.logging_msg("User Logged-out"); // Log
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        // Closes the application
        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("See you soon!");
            logging_activety.logging_msg("App closed"); // Log
            Application.Current.Shutdown();

        }

        // Checks if the input message is legal and then sends it
        private void Button_Send_Click(object sender, RoutedEventArgs e)
        { 
            TextBox box = sender as TextBox;
            Sending temp = new Sending();
            String mes = _main.MessageContent; 
            logging_activety.logging_msg("Message sending attempt..."); // Log
            if (!Legal_Message(mes))
                    return;
            
            _main.Messages.Add("id:" + userlogin.getGroupID() + "  " + userlogin.getID() + ":  " + _main.MessageContent + "   Time:" + DateTime.Now);
            _main.MessageContent = "";
            temp.SendMessage(userlogin , mes , time);
            logging_activety.logging_msg("The message was sent successfully"); // Log

        }

        // Changes the messages interface by the user's choice
        private void Button_Filter_Sort_Click(object sender, EventArgs  e)
        { 
            logging_activety.logging_msg("activate filter"); // Log

            // Send to the Business_Layer the last message time
            Message_List = Business_layer.communication.Retrieve.pullLastMassages(time);
            // The Business_Layer sends this time to the Persistent_Layer
            // The Persistent_Layer checks all the last 200 messages
            // if there is a message that was editted return it
            // else return all the messages that were sent after that last message time


            Message_List = Business_layer.communication.Retrieve.pullallMassages();


            logging_activety.logging_msg("pull new filter instens"); // Log
            FilterAndSort tmp = new FilterAndSort();
            logging_activety.logging_msg("filter identifying"); // Log
            if (RadioButton1.IsChecked==true)
            {
                logging_activety.logging_msg("sort and filter message list"); // Log
                if (!(Combo_Filter.Text.Equals("user")))
                {
                    logging_activety.logging_msg("send filter paremeter to filter fun"); // Log
                    Filtered_Message_List = tmp.Filterandsort(Message_List, Combo_Filter.Text, Combo_Id.Text, "", Combo_Sort.Text, true);
                }
                if (Combo_Filter.Text.Equals("user") & (!(Combo_User.SelectedItem == null)))
                {
                    Filtered_Message_List = tmp.Filterandsort(Message_List, Combo_Filter.Text, iduser(Combo_User.Text), nameuser(Combo_User.Text), Combo_Sort.Text, true);
                }
            }

            if (RadioButton2.IsChecked == true)
            {
                logging_activety.logging_msg("sort and filter"); // Log
                if (!(Combo_Filter.Text.Equals("user")))
                {
                    Filtered_Message_List = tmp.Filterandsort(Message_List, Combo_Filter.Text, Combo_Id.Text, "", Combo_Sort.Text, false);
                }
                if (Combo_Filter.Text.Equals("user")&(!(Combo_User.SelectedItem==null)))
                {
                    Filtered_Message_List = tmp.Filterandsort(Message_List, Combo_Filter.Text, iduser(Combo_User.Text), nameuser(Combo_User.Text), Combo_Sort.Text, false);
                }
            }

            update(Filtered_Message_List);

        }

        //
        public string iduser(string id) {
            
                return (id.Substring(1, id.IndexOf(",") - 1));
            
        }

        //
        public string nameuser(string id)
        {
            return (id.Substring(id.IndexOf(",")+1, id.IndexOf(">")-id.IndexOf(",") - 1));
        }

        // Checks if the typed message is not longer than 100 Chars.
        private bool Legal_Message(String message)
        {
            if (message == null || message.Length > 100)
            {
                logging_activety.logging_msg("ERROR ==========message is too long or empty"); // Log
                MessageBox.Show("Please send a message that's not shorter than 1 and not longer than 100 ");
                return false;
            }

            return true;
        }

    }
}
