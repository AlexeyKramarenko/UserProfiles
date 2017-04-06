using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class UserProfileViewModel
    {       
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
    }
}