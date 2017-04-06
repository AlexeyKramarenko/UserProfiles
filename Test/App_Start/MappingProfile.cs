using AutoMapper;
using Repository.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.App_Start
{
    internal class MappingProfile : AutoMapper.Profile
    {
        [Obsolete]
        protected override void Configure()
        {
            CreateMap<UserProfile, UserProfileViewModel>();
        }
    }
}
