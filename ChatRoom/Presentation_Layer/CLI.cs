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
            Console.WriteLine("2.Log-In Screen.\r\n\r\n");
            Console.WriteLine("UserName : ");
            String Name = Console.ReadLine();
            Console.WriteLine("Password:");
            String password = Console.ReadLine();

            // checks if user is already registered or if it is new , returns true if added returns false if note
            login temp = new login();
            User user =temp.Login(Name, password);
            if (user == null)
            {
                Console.WriteLine("UserName or Password is incorrect");
                System.Threading.Thread.Sleep(3000);
                Console.Clear();
                return;
            }   
            LoggedInScreen(user);
            return;
        }


        public static void RegisterScreen()
        {
            Console.WriteLine("1.Registering Screen.\r\n");
            
            Console.WriteLine("User Name :");
            String UserName = Console.ReadLine();
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
                    Console.WriteLine("the UserID must be a numberpleas try again.");
                }
                id = UserId;
                if(id<0)
                    Console.WriteLine("the UserID must be a numberpleas try again.");
            } while (id == -1| id<0);
            Console.WriteLine("Enter password:");
            String password = Console.ReadLine();

            User user = new User(UserName, id, password);
            register temp = new register();
            User newuser = temp.newRegister(user); 
            if (newuser == null) {
                Console.WriteLine("the User is already registerd");
                System.Threading.Thread.Sleep(3000);
                Console.Clear();
                return ;
            }
            if (!newuser.Get_Nick_Name().Equals(user.Get_Nick_Name()))
            {
                Console.WriteLine("the Group is ulready registerd with another User Name");
                System.Threading.Thread.Sleep(3000);
                Console.Clear();
                return ;
            }
            Console.WriteLine("added!");
            System.Threading.Thread.Sleep(3000);
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

                String Key2 = Console.ReadLine();

                if (Key2 == "1")
                {
                    send_reseve_Massge temp = new send_reseve_Massge();
                    temp.Send(user.Get_Nick_Name(), user.Get_ID());
                }
                    
                else if (Key2 == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Retrieve");
                    List<IMessage> msg=Business_layer.communication.send_reseve_Massge.recallMessage();
                    
                }
                    //
                else if (Key2 == "3")
                {
                    Console.WriteLine("Dispaly");
                }
                    //
                else if (Key2 == "4")
                {
                    Console.WriteLine("Dispaly All");
                }
                    //
                else if (Key2 == "5")
                {
                    Console.WriteLine("Logged Out");      //
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

        public static bool Register(String s1, String s2)
        {
            return true;
        }
    }
}
