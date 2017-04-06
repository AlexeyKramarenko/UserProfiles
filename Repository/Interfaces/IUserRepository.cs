using Repository.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        List<UserProfile> GetSortedUserProfiles(bool sortByAgeAsc, string city);
        List<UserProfile> GetAllProfiles();
    }
}
