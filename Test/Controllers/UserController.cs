using AutoMapper;
using Repository;
using Repository.Interfaces;
using Repository.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class UserController : Controller
    {
        IUserRepository repo = null;
        IMapper mapper = null;
        public UserController(IUserRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public ActionResult List()
        {
            List<UserProfile> profiles = repo.GetAllProfiles();
            var profilesVM = mapper.Map<List<UserProfile>, List<UserProfileViewModel>>(profiles);
            return View(profilesVM);
        }

        [HttpGet]
        public JsonResult GetSortedUserProfileList(int sortByAgeAsc, string city)
        {
            bool sortByAge = Convert.ToBoolean(sortByAgeAsc);
            List<UserProfile> profiles = repo.GetSortedUserProfiles(sortByAge, city);
            var profilesVM = mapper.Map<List<UserProfile>, List<UserProfileViewModel>>(profiles);
            return Json(new { profilesVM }, JsonRequestBehavior.AllowGet);
        }

    }
}
