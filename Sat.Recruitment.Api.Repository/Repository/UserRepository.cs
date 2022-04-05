using Sat.Recruitment.Infrastructure.Model;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruitment.Api.IRepository;

namespace Sat.Recruitment.Api.Repository
{
    public class UserRepository :IUserRepository
    {
        /// <summary>
        /// Read all the records from the file
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsersFromFile()
        {
            List<User> _users = new List<User>();

            string path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while (reader.Peek() >= 0)
                {
                    string[] line = reader.ReadLineAsync().Result.Split(',');
                    var user = new User()
                    {
                        Name = line[0],
                        Email = line[1],
                        Phone = line[2],
                        Address = line[3],
                        UserType = line[4],
                        Money = decimal.Parse(line[5]),
                    };
                    _users.Add(user);
                }
                reader.Close();
            }
            return _users;
        }
    }
}
