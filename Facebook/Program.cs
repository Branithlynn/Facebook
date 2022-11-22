using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Entities;
using Facebook.Tools;
using Facebook.Views;

namespace Facebook
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeView homeView = new HomeView();
            homeView.Run();
        }
    }
}
