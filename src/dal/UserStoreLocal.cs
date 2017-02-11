using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Model;

namespace Dal
{
    public class UserStoreLocal : IUserStore
    {
        private readonly List<User> _allUsers = new List<User>
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
        public Task<User> Authenticate(string email, string hashPassword)
        {
            return Task<User>.Run(() => _allUsers.FirstOrDefault(u => u.Email == email));
        }

        public Task<User> FindUser(string email)
        {
            return Task<User>.Run(() => _allUsers.FirstOrDefault(u => u.Email == email));
        }

        public Task ReigsterUser(User newUser)
        {
            return Task.Run(() =>
            {
				if (_allUsers.Any(u => u.Email.Equals(newUser.Email, StringComparison.OrdinalIgnoreCase)
					|| u.NickName.Equals(newUser.NickName, StringComparison.OrdinalIgnoreCase)))
					throw new Exception("");
                _allUsers.Add(newUser);

            });
        }
    }
}
