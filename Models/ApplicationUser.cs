using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneStopBuy.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string User_Username { get; set; }

        public string ProfilePicture { get; set; }

        public string Bio { get; set; }

        public bool VerifiedAccout { get; set; }
    }
}
