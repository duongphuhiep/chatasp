using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Models;

namespace Dal
{
    public interface IUserStore
    {
        Task<User> Authenticate(string email, string hashPassword);
        Task<User> FindUser(string email);
        Task AddUser(User u);
    }
}
