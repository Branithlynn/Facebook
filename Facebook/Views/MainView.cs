using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.DataAccess;
using Facebook.Entities;

namespace Facebook.Views
{
    public class MainView
    {
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Main Menu:");
                Console.WriteLine("[U]sers Management");
                Console.WriteLine("E[x]it");
                Console.Write(">");

                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "u":
                        {
                            UsersManagerView view = new UsersManagerView();
                            view.Run();
                            break;
                        }
                    case "x":
                        {
                            Console.Clear();
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
    }
}
