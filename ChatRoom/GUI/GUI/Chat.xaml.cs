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
        private List<Message> Message_List = new List<Message>();
        private List<Message> Filtered_Message_List= new List<Message>();
        DispatcherTimer timer = new DispatcherTimer();
        int editIndex = -1;

        //Creates the windows' display
        public Chat(User userlogin)
        {
            Retrieve retrieve = new Retrieve();
            Message_List = retrieve.pullLastMassages();
            this.DataContext = _main;
            this.userlogin = userlogin;
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Button_Filter_Sort_Click;/*update(retrieve.pullLastMassages());*/
            timer.Start();
            
        }
        //Enter
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //loging the activety of the project 
                logging_activety.logging_msg("enter activation from user to send message");
                TextBox box = sender as TextBox;
                _main.MessageContent = box.Text;
            }
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
                    _main.Messages.Add((String)("id:" + x.getGroupID() + "  " + x.getSender() + ":  " + x.getContent() + "   Time:" + x.getTime()));

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
            bool success = temp.SendMessage(userlogin , mes , DateTime.Now);
            if(success)
                logging_activety.logging_msg("The message was sent successfully"); // Log
            else
            {
                logging_activety.logging_msg("Lost connection with the database"); // Log
                MessageBox.Show("Could not send message , please check your connection");
            }
        }

        // Changes the messages interface by the user's choice
        private void Button_Filter_Sort_Click(object sender, EventArgs  e)
        {
            Retrieve updateMessages = new Retrieve();
            DateTime lastMessageTime = Message_List.Last().getTime();
            Message_List.AddRange(updateMessages.pullNewMassages(lastMessageTime));
            if (Combo_Filter.Text.Equals("group") && !(Combo_Id.SelectedItem == null)) {
                Message_List = updateMessages.Filterid(Combo_Id.Text);
            }
            if (Combo_Filter.Text.Equals("user") && !(Combo_User.SelectedItem == null)) {
                Message_List = updateMessages.Filteruser(iduser(Combo_User.Text),nameuser(Combo_User.Text));
            }
            FilterAndSort tmp = new FilterAndSort();
            Filtered_Message_List = tmp.Filterandsort(Message_List, Combo_Sort.Text, RadioButton1.IsChecked==true);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sending temp = new Sending();
            String newContent = Text_Edit.Text;
            if(!Legal_Message(newContent))
                return;
            
            Message message = Message_List.ElementAt(editIndex);
            bool k =temp.EditMessage( message , newContent , DateTime.Now);
            MessageBox.Show("Message was edited Successfully");


        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Box_Messages.SelectedIndex;
            if (index != -1)
            {
                Message check = Message_List.ElementAt(index);

                if (userlogin.getID() == check.getID())
                {
                    editIndex = index;
                    Text_Edit.Visibility = Visibility.Visible;
                    Button_Edit.Visibility = Visibility.Visible;
                    Text_Edit.Text = check.getContent();
             //       MessageBox.Show("");
                }

                else
                {
                    Text_Edit.Visibility = Visibility.Hidden;
                    Button_Edit.Visibility = Visibility.Hidden;
                    Text_Edit.Text = String.Empty;
                }
            }


        }
    }
}
