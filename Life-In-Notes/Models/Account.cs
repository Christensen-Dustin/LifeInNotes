using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Life_In_Notes.Models
{
    public class Account : IdentityUser
    {
        // User First Name
        public string NameFirst { get; set; }

        // User Last Name
        public string NameLast { get; set; }
    }
}
