using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ProjectAlbar.Models;
using ProjectAlbar.DL;

namespace ProjectAlbar.BL
{
    public class userBL : IUserBL
    {
        IUserDL iuserDL;
        public userBL(IUserDL iuserDL)
        {
            this.iuserDL = iuserDL;
        }

        public async Task<User> getUser(string username, string password)
        {
            User user;
            user = await iuserDL.getUser(username, password);
            return user;
        }

        public async Task<int> postUser(User user)
        {
            user.LastLogIn = DateTime.Now;
            return await iuserDL.postUser(user);
        }

        public async Task<User> putUser(User user, int id)
        {
            await iuserDL.putUser(user, id);
            return user;
        }
    }
}
