using Repository.POCO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserDbContext : DbContext
    {
        public UserDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new DBInitializer());
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    public class DBInitializer : DropCreateDatabaseAlways<UserDbContext>
    {
        protected override void Seed(UserDbContext db)
        {
            db.UserProfiles.Add(new UserProfile { Name = "Саша", City = "Київ", Age = 18 });
            db.UserProfiles.Add(new UserProfile { Name = "Аня", City = "Львів", Age = 25 });
            db.UserProfiles.Add(new UserProfile { Name = "Віка", City = "Харьків", Age = 22 });
            db.UserProfiles.Add(new UserProfile { Name = "Ігор", City = "Київ", Age = 40 });
            db.UserProfiles.Add(new UserProfile { Name = "Ваня", City = "Львів", Age = 16 });

            db.SaveChanges();
        }
    }
}
