using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.DataAccess;
using Facebook.Entities;

namespace Facebook.Views
{
    public class HomeView
    {
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Home Menu:");
                Console.WriteLine("[L]ogin");
                Console.WriteLine("[R]egister");
                Console.WriteLine("E[x]it");
                Console.Write(">");

                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "l":
                        {
                            Login();
                            break;
                        }
                    case "r":
                        {
                            Register();
                            break;
                        }
                    case "x":
                        {
                            Console.Clear();
                            Console.WriteLine("Goodbye!");
                            Console.ReadKey(true);
                            return;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid choice!");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }

        public void Login()
        {
            Console.Clear();
            Console.WriteLine("Login:");

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            User user = null;

            UsersDA userDa = new UsersDA();
            user = userDa.GetByUsernameAndPassword(username, password);

            if (user != null)
            {
                MainView mainView = new MainView();
                mainView.Run();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Authentication failed!");
                Console.ReadKey(true);
            }
        }

        public void Register()
        {
            Console.Clear();
            Console.WriteLine("Register:");
            
            User item = new User();

            Console.Write("Username: ");
            item.Username = Console.ReadLine();

            Console.Write("Password: ");
            item.Password = Console.ReadLine();

            Console.Write("First Name: ");
            item.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            item.LastName = Console.ReadLine();

            UsersDA usersDA = new UsersDA();
            usersDA.Insert(item);

            Console.WriteLine("Registration successful!");

            Console.ReadKey(true);
        }
    }
}
