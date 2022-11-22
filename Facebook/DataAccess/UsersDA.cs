using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Facebook.Entities;
using Facebook.Tools;

namespace Facebook.DataAccess
{
    public class UsersDA
    {
        public LinkedList<User> GetAll()
        {
            LinkedList<User> result = new LinkedList<User>();

            FileStream fs = new FileStream("users.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            while (sr.EndOfStream == false)
            {
                User item = new User();
                item.Username = sr.ReadLine();
                item.Password = sr.ReadLine();
                item.FirstName = sr.ReadLine();
                item.LastName = sr.ReadLine();

                result.Add(item);
            }

            sr.Close();
            fs.Close();

            return result;
        }

        public void Insert(User item)
        {
            FileStream fs = new FileStream("users.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(item.Username);
            sw.WriteLine(item.Password);
            sw.WriteLine(item.FirstName);
            sw.WriteLine(item.LastName);

            sw.Close();
            fs.Close();
        }

        public void Update(User item)
        {
            FileStream fs = new FileStream("users.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            FileStream tempfs = new FileStream("tempusers.txt", FileMode.OpenOrCreate);
            StreamWriter tempsw = new StreamWriter(tempfs);

            while(sr.EndOfStream == false)
            {
                User user = new User();
                user.Username = sr.ReadLine();
                user.Password = sr.ReadLine();
                user.FirstName = sr.ReadLine();
                user.LastName = sr.ReadLine();

                if (user.Username == item.Username)
                {
                    tempsw.WriteLine(item.Username);
                    tempsw.WriteLine(item.Password);
                    tempsw.WriteLine(item.FirstName);
                    tempsw.WriteLine(item.LastName);
                }
                else
                {
                    tempsw.WriteLine(user.Username);
                    tempsw.WriteLine(user.Password);
                    tempsw.WriteLine(user.FirstName);
                    tempsw.WriteLine(user.LastName);
                }
            }

            sr.Close();
            fs.Close();

            tempsw.Close();
            tempfs.Close();

            File.Delete("users.txt");
            File.Move("tempusers.txt", "users.txt");

        }

        public void Delete(User item)
        {
            FileStream fs = new FileStream("users.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            FileStream tempfs = new FileStream("tempusers.txt", FileMode.OpenOrCreate);
            StreamWriter tempsw = new StreamWriter(tempfs);

            while (sr.EndOfStream == false)
            {
                User user = new User();
                user.Username = sr.ReadLine();
                user.Password = sr.ReadLine();
                user.FirstName = sr.ReadLine();
                user.LastName = sr.ReadLine();

                if (user.Username == item.Username)
                    continue;

                tempsw.WriteLine(user.Username);
                tempsw.WriteLine(user.Password);
                tempsw.WriteLine(user.FirstName);
                tempsw.WriteLine(user.LastName);
            }

            sr.Close();
            fs.Close();

            tempsw.Close();
            tempfs.Close();

            File.Delete("users.txt");
            File.Move("tempusers.txt", "users.txt");

        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            FileStream fs = new FileStream("users.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            User user = null;
            while(sr.EndOfStream == false)
            {
                User item = new User();
                item.Username = sr.ReadLine();
                item.Password = sr.ReadLine();
                item.FirstName = sr.ReadLine();
                item.LastName = sr.ReadLine();

                if (item.Username == username && item.Password == password)
                {
                    user = item;
                    break;
                }
            }

            sr.Close();
            fs.Close();

            return user;
        }

        public User GetByUsername(string username)
        {
            FileStream fs = new FileStream("users.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            User user = null;
            while (sr.EndOfStream == false)
            {
                User item = new User();
                item.Username = sr.ReadLine();
                item.Password = sr.ReadLine();
                item.FirstName = sr.ReadLine();
                item.LastName = sr.ReadLine();

                if (item.Username == username)
                {
                    user = item;
                    break;
                }
            }

            sr.Close();
            fs.Close();

            return user;
        }
    }
}
