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
        private List<Message> Message_List;
        private List<Message> Filtered_Message_List;
        DispatcherTimer timer = new DispatcherTimer();
        public Chat(User userlogin)
        {

            this.DataContext = _main;
            this.userlogin = userlogin;
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Button_Filter_Sort_Click;/*update;*/
            timer.Start();
            //Message_List = Business_layer.communication.send_reseve_Massge.recallMessage();
            //update(Message_List);

        }
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
        
        private void update(List<Message> Message_List/*object sender, EventArgs e*/)
        {

            //Message_List = Business_layer.communication.send_reseve_Massge.recallMessage();
            // updates the Filtered_Message_List using current filter and sort , so that the textblock text will be binded to it
            //.Text = String.Empty;
            _main.Messages.Clear();
            //loging the activety of the project 
            logging_activety.logging_msg("message update for every 2 sec");
            foreach (Message x in Message_List)
            {
                {
                    _main.Messages.Add((String)("id:" + x.grupid + "  " + x.UserName + ":  " + x.MessageContent + "   Time:" + x.Data ));
                    //Block_Messages.Inlines.Add("id:" + x.grupid + "  " + x.UserName + ":  " + x.MessageContent + "   Time:" + x.Data + "\r");
                    if (!(Combo_Id.Items.Contains(x.grupid)))
                    {
                        Combo_Id.Items.Add(x.grupid);
                    }
                    if (!(Combo_User.Items.Contains("<" + x.grupid + "," + x.UserName + ">")))
                    {
                        Combo_User.Items.Add("<" + x.grupid + "," + x.UserName + ">");
                    }
                }
            }
           
        }

        private void Button_Logout_Click(object sender, RoutedEventArgs e)
        {
            //loging the activety of the project 
            logging_activety.logging_msg("send to singin window");
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }



        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            //loging the activety of the project 
            logging_activety.logging_msg("Exit from the app");
            MessageBox.Show("See you soon!");
            Application.Current.Shutdown();

        }


        private void Button_Send_Click(object sender, RoutedEventArgs e)
        {
            //loging the activety of the project 
            logging_activety.logging_msg("send button activat");
            TextBox box = sender as TextBox;

            send_reseve_Massge temp = new send_reseve_Massge();
            String mes;
            mes = _main.MessageContent;
            //loging the activety of the project 
            logging_activety.logging_msg("message text check...");
            if (mes.Length > 150 | mes.Length < 1)
            {
                //loging the activety of the project 
                logging_activety.logging_msg("ERROR ==========message is too longe or empty");
                MessageBox.Show("Please send a message that's not shorter than 1 and not longer than 150  ");
            }
            else
            {
                //loging the activety of the project 
                logging_activety.logging_msg("send message by user");
                _main.Messages.Add("id:" + userlogin.GroupID + "  " + userlogin.Name + ":  " + _main.MessageContent + "   Time:" + DateTime.Now);
                _main.MessageContent = "";
                temp.Send(userlogin.Get_Nick_Name(), userlogin.Get_ID(), mes);
            }
            //_main.Messages.Add(_main.MessageContent);
            //_main.MessageContent = "";
           // Text_Message.Clear();
        }


        private void Button_Filter_Sort_Click(object sender, EventArgs  e)
        {
            //loging the activety of the project 
            logging_activety.logging_msg("activat filter");
            //if (timer.IsEnabled)
            //    timer.Stop();
            //else
            //  timer.Start();
            Message_List = Business_layer.communication.Retrieve.pullallMassages();
            //loging the activety of the project 
            logging_activety.logging_msg("pul new filter instens");
            FilterAndSort tmp = new FilterAndSort();
            //loging the activety of the project 
            logging_activety.logging_msg("filter Identefing");
            if (RadioButton1.IsChecked==true)
            {
                //loging the activety of the project 
                logging_activety.logging_msg("sort and filter message list");
                if (!(Combo_Filter.Text.Equals("user")))
                {
                    //loging the activety of the project 
                    logging_activety.logging_msg("send filter paremeter to filter fun");
                    Filtered_Message_List = tmp.Filterandsort(Message_List, Combo_Filter.Text, Combo_Id.Text, "", Combo_Sort.Text, true);
                }
                if (Combo_Filter.Text.Equals("user") & (!(Combo_User.SelectedItem == null)))
                {
                    Filtered_Message_List = tmp.Filterandsort(Message_List, Combo_Filter.Text, iduser(Combo_User.Text), nameuser(Combo_User.Text), Combo_Sort.Text, true);
                }
            }

            if (RadioButton2.IsChecked == true)
            {
                //loging the activety of the project 
                logging_activety.logging_msg("sort and filter");
                if (!(Combo_Filter.Text.Equals("user")))
                {
                    Filtered_Message_List = tmp.Filterandsort(Message_List, Combo_Filter.Text, Combo_Id.Text, "", Combo_Sort.Text, false);
                }
                if (Combo_Filter.Text.Equals("user")&(!(Combo_User.SelectedItem==null)))
                {
                    Filtered_Message_List = tmp.Filterandsort(Message_List, Combo_Filter.Text, iduser(Combo_User.Text), nameuser(Combo_User.Text), Combo_Sort.Text, false);
                }
            }

            //Block_Messages.Text = String.Empty;
            //foreach (Message x in Message_List)
            //{
            //    Block_Messages.Inlines.Add("id:" + x.grupid + "  " + x.UserName + ":  " + x.MessageContent + "   Time:" + x.Data + "\r");
            //}
            update(Filtered_Message_List);

        }
        public string iduser(string id) {
            
                return (id.Substring(1, id.IndexOf(",") - 1));
            
        }
        public string nameuser(string id)
        {
            return (id.Substring(id.IndexOf(",")+1, id.IndexOf(">")-id.IndexOf(",") - 1));
        }

        

    }
}
