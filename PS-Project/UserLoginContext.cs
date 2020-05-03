using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class UserLoginContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserLoginContext() : base(Properties.Settings.Default.DbConnect)
        { }
    }
}
