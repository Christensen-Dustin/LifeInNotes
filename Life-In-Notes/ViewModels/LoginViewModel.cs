using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Life_In_Notes.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Entry Name cannot exceed 50 characters")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
