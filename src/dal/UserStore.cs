using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Model;

namespace dal
{
    public static class UserStore
    {
        private static readonly List<User> _allUsers = new List<User>
        {
            new User
            {
                Email = "foo@email.com",
                NickName = "Foo"
            },
            new User
            {
                Email = "bar@email.com",
                NickName = "Bar"
            }
        };

        /// <summary>
        /// return true if find matching user, password in the store
        /// </summary>
        public static Task<User> Authenticate(string email, string hashPassword)
        {
            return Task<User>.Run(()=> _allUsers.FirstOrDefault(u => u.Email == email));
        }

        public static Task<User> FindUser(string email)
        {
            return Task<User>.Run(()=> _allUsers.FirstOrDefault(u => u.Email == email));
        }
    }
}