using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_layer.Login_out;
using Business_layer;
using persistent_layer.Data_type;

namespace Presentation_Layer
{
    class CLI
    {

        static void Main(string[] args)
        {
            User loged_in_user = null;
            bool loged_in = false;
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
                    loged_in_user=RegisterScreen();
                    if (loged_in_user != null)
                        loged_in = true;
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


            Console.ReadKey();
            Console.Clear();
        }


        public static User RegisterScreen()
        {
            Console.WriteLine("1.Registering Screen.\r\n");
            
            Console.WriteLine("User Name :");
            String UserName = Console.ReadLine();
            int id = -1;
            do
            {
                Console.WriteLine("Group ID :");
                String UserId = Console.ReadLine();
                if (Int32.TryParse(UserId, out id))
                {

                }
                    //Console.WriteLine(id);
                else
                    Console.WriteLine("the UserID must be a numberpleas try again.");
            } while (id == -1|id<0);
            Console.WriteLine("Enter password:");
            String password = Console.ReadLine();

            User user = new User(UserName, id, password);
            Console.WriteLine(user.Get_Nick_Name());
            Console.ReadLine();
            register temp = new register();
            User newuser = temp.newRegister(user); 
            if (newuser == null) {
                Console.WriteLine("the User is already registerd");
                return null;
            }
            if (!newuser.Get_Nick_Name().Equals(user.Get_Nick_Name()))
            {
                Console.WriteLine("the Group is ulready registerd with another User Name");
                return null;
            }
            Console.WriteLine("added!");
            return newuser;
        }



        public static void LoggedInScreen(User user)    // User Account gets
        {

            bool LoggedIn = true;

            while (LoggedIn)
            {
                Console.WriteLine("1.Write (and send) a new message (max. Length 150 characters).");
                Console.WriteLine("2.Retrieve last 10 messages from the server");
                Console.WriteLine("3.Display last 20 retrieved messages");
                Console.WriteLine("4.Display all retrieved messages");
                Console.WriteLine("5.Logout");
                Console.WriteLine("6.Exit");

                String Key2 = Console.ReadLine();

                if (Key2 == "1")
                    Console.WriteLine("Sends a Message");     //
                if (Key2 == "2")
                    Console.WriteLine("Retrieve");            //
                if (Key2 == "3")
                    Console.WriteLine("Dispaly");             //
                if (Key2 == "4")
                    Console.WriteLine("Dispaly All");         //
                if (Key2 == "5")
                {
                    Console.WriteLine("Logged Out");      //
                    LoggedIn = false;
                }
                if (Key2 == "6")
                {
                    Console.WriteLine("Logged Out");      //
                    
                }

            }
        }

        public static bool Register(String s1, String s2)
        {
            return true;
        }
    }
}
