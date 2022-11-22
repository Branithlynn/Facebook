using System;
using Facebook.DataAccess;
using Facebook.Entities;
using Facebook.Tools;

namespace Facebook.Views
{
    public class UsersManagerView
    {
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("User Management:");
                Console.WriteLine("[L]ist");
                Console.WriteLine("[A]dd");
                Console.WriteLine("[E]dit");
                Console.WriteLine("[D]elete");
                Console.WriteLine("E[x]it");
                Console.Write(">");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "l":
                        {
                            List();
                            break;
                        }
                    case "a":
                        {
                            Add();
                            break;
                        }
                    case "e":
                        {
                            Update();
                            break;
                        }
                    case "d":
                        {
                            Delete();
                            break;
                        }
                    case "x":
                        {
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

        private void List()
        {
            Console.Clear();

            Console.WriteLine("List Users:");

            UsersDA usersDa = new UsersDA();
            LinkedList<User> list = usersDa.GetAll();

            for (int i = 0; i < list.Count(); i++)
            {
                Console.WriteLine("Username: {0}", list.GetAt(i).Username);
                Console.WriteLine("First Name: {0}", list.GetAt(i).FirstName);
                Console.WriteLine("Last Name: {0}", list.GetAt(i).LastName);
                Console.WriteLine("#########################");
            }

            Console.ReadKey(true);
        }

        private void Add()
        {
            Console.Clear();
            Console.WriteLine("Add User:");

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

            Console.WriteLine("User successfully added!");

            Console.ReadKey(true);
        }

        private void Update()
        {
            Console.Clear();
            Console.WriteLine("Update User:");

            Console.Write("Username: ");
            string username = Console.ReadLine();

            UsersDA usersDA = new UsersDA();

            User user = usersDA.GetByUsername(username);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("*****Original Data*****");
            Console.WriteLine("Username: {0}", user.Username);
            Console.WriteLine("Password: {0}", user.Password);
            Console.WriteLine("First Name: {0}", user.FirstName);
            Console.WriteLine("Last Name: {0}", user.LastName);

            Console.WriteLine("*****New Data*****");
            Console.WriteLine("Username: {0}", user.Username);
            Console.Write("Password:");
            user.Password = Console.ReadLine();
            Console.Write("First Name:");
            user.FirstName = Console.ReadLine();
            Console.Write("Last Name:");
            user.LastName = Console.ReadLine();

            usersDA.Update(user);

            Console.WriteLine("Item updated!");
            Console.ReadKey(true);
        }

        private void Delete()
        {
            Console.Clear();
            Console.WriteLine("Delete User:");

            Console.Write("Username: ");
            string username = Console.ReadLine();

            UsersDA usersDA = new UsersDA();

            User user = usersDA.GetByUsername(username);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                Console.ReadKey(true);
                return;
            }

            usersDA.Delete(user);

            Console.WriteLine("Item deleted!");
            Console.ReadKey(true);
        }
    }
}
