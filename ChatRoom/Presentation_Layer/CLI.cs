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
            User loged_in_user;
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
                    RegisterScreen();
                }
                else if (Key.Equals("2"))
                {
                    Console.Clear();
                    LoginScreen(Key);
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

        public static void LoginScreen(String Key)
        {
            Console.WriteLine("2.Log-In Screen.\r\n\r\n");
            Console.WriteLine("User Name :");
            String UserName = Console.ReadLine();
            int id = -1;
            do
            {
                Console.WriteLine("User ID :");
                String UserId = Console.ReadLine();
                if (Int32.TryParse("UserId", out id))
                    Console.WriteLine(id);
                else
                    Console.WriteLine("the UserID must be a numberpleas try again.");
            } while (id != -1&id>0);
            Console.WriteLine("Enter password:");
            String password = Console.ReadLine();

            User user = new User(UserName, id, password);
            new register
            int i= login. //(UserName, password);
            //   User Account = new User(UserName, UserId);
            //   if (Account.isRegistered(UserName, UserId) == false)
            //  {
            //       Console.WriteLine("User not found!");
            //       Console.ReadKey();
            //       Console.Clear();
            //  }

            //      else LoggedInScreen(Account, Key);
        }


        public static void RegisterScreen()
        {
            Console.WriteLine("1.Registering Screen.\r\n");
            Console.WriteLine("UserName : ");
            String Name = Console.ReadLine();
            Console.WriteLine("ID:");
            String ID = Console.ReadLine();

            bool done = Register(Name, ID);    // checks if user is already registered or if it is new , returns true if added returns false if note
            if (done)
                Console.WriteLine("added!");
            else
                Console.WriteLine("User is already registered!");


            Console.ReadKey();
            Console.Clear();

        }



        public static void LoggedInScreen(String Key)    // User Account gets
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
                    Key = "3";
                }

            }
        }

        public static bool Register(String s1, String s2)
        {
            return true;
        }
    }
}
