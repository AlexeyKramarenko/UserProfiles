using Repository.Interfaces;
using Repository.POCO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class UserRepository : IUserRepository, IDisposable
    {
        UserDbContext db = null;
        public UserRepository()
        {
            this.db = new UserDbContext();
        }
        public List<UserProfile> GetSortedUserProfiles(bool sortByAgeAsc, string city)
        {
            IQueryable<UserProfile> profiles = null;

            if (!string.IsNullOrEmpty(city) && city != "all")
                profiles = db.UserProfiles.Where(a => a.City == city);
            else
                profiles = db.UserProfiles;

            if (sortByAgeAsc)
                profiles = profiles.OrderBy(p => p.Age);
            else
                profiles = profiles.OrderByDescending(p => p.Age);

            return profiles.ToList();
        }
        public List<UserProfile> GetAllProfiles()
        {
            var profiles = db.UserProfiles.Select(a => new { a.Age, a.City, a.Name })
                                          .AsEnumerable()
                                          .Select(e => new UserProfile { Age = e.Age, City = e.City, Name = e.Name })
                                          .ToList();
            return profiles;
        }


        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


}
