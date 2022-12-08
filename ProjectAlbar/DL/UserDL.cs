using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ProjectAlbar.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProjectAlbar.DL
{
    public class UserDL : IUserDL
    {
        DBprojectAlbar DBprojectAlbar;

        public UserDL(DBprojectAlbar DBprojectAlbar)
        {
            this.DBprojectAlbar = DBprojectAlbar;
        }

        public async Task<User> getUser(string username, string password)
        {
            var userToGet = await DBprojectAlbar.Users.Where(u =>
             u.Username == username && u.Password == password
            ).FirstOrDefaultAsync();
            if (userToGet == null)
                return null;
            return userToGet;
        }

        public async Task<int> postUser(User user)
        {
            try
            {
                using (var context = new DBprojectAlbar())
                {
                    await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();
                }
                return 1;
            }
            catch
            {
                Console.WriteLine("ERR");
                return -1;
            }
        }

        public async Task<User> putUser(User user, int id)
        {
            var userToChange = await DBprojectAlbar.Users.FindAsync(id);
            user.UserId = id;
            DBprojectAlbar.Entry(userToChange).CurrentValues.SetValues(user);
            await DBprojectAlbar.SaveChangesAsync();
            return userToChange;
        }

    }
}
