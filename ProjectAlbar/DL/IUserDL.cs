using System.Threading.Tasks;
using ProjectAlbar.Models;
namespace ProjectAlbar.DL
{
    public interface IUserDL
    {
        Task<User> getUser(string username, string password);
        Task<int> postUser(User user);
        Task<User> putUser(User user, int id);
    }
}