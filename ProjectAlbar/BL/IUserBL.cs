using System.Threading.Tasks;
using ProjectAlbar.Models;

namespace ProjectAlbar.BL
{
    public interface IUserBL
    {
        Task<User> getUser(string email, string password);
        Task<int> postUser(User user);
        Task<User> putUser(User user, int id);
    }
}