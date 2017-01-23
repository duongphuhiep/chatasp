using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Model;

namespace Dal
{
    public interface IUserStore
    {
        Task<User> Authenticate(string email, string hashPassword);
        Task<User> FindUser(string email);
        Task ReigsterUser(User u);
    }
}