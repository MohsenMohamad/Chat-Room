using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_layer.Login_out;
using Business_layer;
using persistent_layer.Data_type;
using Business_layer.communication;
using Communication_Layer.CommunicationLayer;

namespace Presentation_Layer
{
    class CLI
    {

        static void Main(string[] args)
        {
            // load info from database()
            for (; ; )
            {
                Console.WriteLine("1.Register");
                Console.WriteLine("2.Login");
                Console.WriteLine("3.Exit");

                String Key = Console.ReadLine();
                logging_activety.logging_msg("User input in the Main screen is " + Key);
                if (Key.Equals("1"))
                {
                    Console.Clear();
                    RegisterScreen();
                    Console.Clear();
                }
                else if (Key.Equals("2"))
                {
                    Console.Clear();
                    LoginScreen();
                }
                else if (Key.Equals("3"))
                    break;
                else
                {
                    Console.WriteLine("invaled entery please try again");
                    System.Threading.Thread.Sleep(3000);
                    Console.Clear();
                }
            }
        }

        public static void LoginScreen()
        {
            String Name;
            String password;
            do
            {
                Console.WriteLine("2.Log-In Screen.\r\n\r\n");
                Console.WriteLine("UserName : ");
                Name = Console.ReadLine();
            } while (Name=="");
            do { 
                Console.WriteLine("Password:");
                password = Console.ReadLine();
            } while (password == "");
            // checks if user is already registered or if it is new , returns true if added returns false if note
            login temp = new login();
            User user =temp.Login(Name, password);
            if (user == null)
            {
                Console.WriteLine("UserName or Password is incorrect");
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                return;
            }   
            LoggedInScreen(user);
            return;
        }


        public static void RegisterScreen()
        {
            String UserName;
            String password;
            Console.WriteLine("1.Registering Screen.\r\n");

            do { 
            Console.WriteLine("User Name :");
            UserName = Console.ReadLine();
            } while (UserName=="");
            int id = -1;
            do
            {
                Console.WriteLine("Group ID :");
                int UserId=-1;
                try
                {
                    UserId = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("the UserID must be a number pleas try again.");
                }
                id = UserId;
                if(id<0)
                    Console.WriteLine("the UserID must be a number pleas try again.");
            } while (id == -1| id<0);
            do
            {
                Console.WriteLine("Enter password:");
                password = Console.ReadLine();
            } while (password == "");
            User user = new User(UserName, id, password);
            register temp = new register();
            User newuser = temp.newRegister(user); 
            if (newuser == null) {
                Console.WriteLine("the User is already registerd");
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                return ;
            }
            if (!newuser.Get_Nick_Name().Equals(user.Get_Nick_Name()))
            {
                Console.WriteLine("the Group is ulready registerd with another User Name");
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                return ;
            }
            Console.WriteLine("added!");
            System.Threading.Thread.Sleep(1500);
            Console.Clear();
            LoggedInScreen(user);
            return;
        }



        public static void LoggedInScreen(User user)    // User Account gets
        {

            bool LoggedIn = true;

            while (LoggedIn)
            {
                Console.WriteLine("1.Write (and send) a new message (max. Length 150 characters).");
                Console.WriteLine("2.Retrieve last 10 messages from the server");
                Console.WriteLine("3.Display last 20 retrieved messages");
                Console.WriteLine("4.Display all sent by this user messages");
                Console.WriteLine("5.Logout");
                Console.WriteLine();
                Console.WriteLine();
                String Key2;
                do
                {
                    Key2 = Console.ReadLine();
                } while (Key2 == "");
                logging_activety.logging_msg("User input in the Login screen is :" + Key2);
                if (Key2 == "1")
                {
                    send_reseve_Massge temp = new send_reseve_Massge();
                    bool m = false;
                    string mes;
                    do
                    {
                        Console.WriteLine("Enter your message with Limet of 150 charctar");
                        mes = Console.ReadLine();
                        logging_activety.logging_msg("User input in the wright message screen is :" + mes);
                        if (mes.Length > 150|mes.Length<1)
                        {
                            Console.WriteLine("the message you Enterd is too long or too short pleas try again");
                            m = true;
                        }
                        else
                        {
                            m = false;
                        }
                    } while (m);
                    temp.Send(user.Get_Nick_Name(), user.Get_ID(),mes);
                    Console.WriteLine("Message sent...");
                    Console.Read();
                    Console.Clear();
                }
                    
                else if (Key2 == "2")
                {
                    logging_activety.logging_msg("trying to retreve the last messages on the server");
                    //Console.WriteLine("Retrieved");
                    List<Message> msg=Business_layer.communication.send_reseve_Massge.recallMessage();
                    foreach(Message x in msg)
                    {
                        Console.WriteLine();
                        Console.WriteLine(x.UserName+":                 "+x.Data);
                        Console.WriteLine(x.MessageContent);
                    }
                    Console.Read();
                    Console.Clear();

                }
                    //
                else if (Key2 == "3")
                {
                    logging_activety.logging_msg("retriving the last 20 messages stored in the data base");
                    
                    List<Message> msg = Business_layer.communication.Retrieve.pullLastMassages();
                    if (msg.Count()>0)
                        foreach (Message x in msg)
                        {
                            Console.WriteLine(x.UserName + ":     "+x.Data);
                            Console.WriteLine(x.MessageContent);
                            Console.WriteLine();
                        }
                    else
                        Console.WriteLine("no messages sent by this User");
                    
                    Console.WriteLine("Dispaly");
                    Console.Read();
                    Console.Clear();
                }
                    //
                else if (Key2 == "4")
                {
                    logging_activety.logging_msg("retriving the messages sent by the user from the data base" );
                    Console.WriteLine("Dispaly All");
                   
                    List<Message> msg = Business_layer.communication.Retrieve.pullMassages(user);
                    if (msg.Count>0) 
                        foreach (Message x in msg)
                        {
                            Console.WriteLine(x.Data + ":");
                            Console.WriteLine(x.MessageContent);
                        }
                    else
                        Console.WriteLine("no messages sent by this User");
                        
                    Console.Read();
                    Console.Clear();
                }
                    
                else if (Key2 == "5")
                {
                    logging_activety.logging_msg("logging out from the login screen");
                    Console.WriteLine("Logged Out...");      //
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    LoggedIn = false;
                }
                else
                {
                    Console.WriteLine("invaled input ... please try again after 3 sec");
                    Console.Clear();
                }

            }
        }
    }
}
