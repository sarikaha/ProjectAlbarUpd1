using System;
using System.Collections.Generic;

//#nullable disable

namespace ProjectAlbar.Models
{
    public partial class User
    {
        public User()
        {
            //Orders = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastLogIn { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }
    }
}
