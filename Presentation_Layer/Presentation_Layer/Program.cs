using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    class Program
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
                }

                if (Key.Equals("2"))
                {
                    Console.Clear();
                    LoginScreen(Key);
                }
                if (Key.Equals("3"))
                    break;

            }
        }

        public static void LoginScreen(String Key)
        {
            Console.WriteLine("2.Log-In Screen.\r\n\r\n");
            Console.WriteLine("User Name :");
            String UserName = Console.ReadLine();
            Console.WriteLine("User ID :");
            String UserId = Console.ReadLine();

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
            Console.WriteLine("1.Registering Screen.\r\n\r\n");
            Console.WriteLine("UserName : ");
            String Name = Console.ReadLine();
            Console.WriteLine("ID:");
            String ID = Console.ReadLine();

            bool done = register(Name, ID);    // checks if user is already registered or if it is new , returns true if added returns false if note
            if (done) Console.WriteLine("added!");
            else Console.WriteLine("User is already registered!");


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

        public static bool register(String s1, String s2)
        {
            return true;
        }
    }
}
    
