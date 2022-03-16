using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Newsopedia.Services.Models
{
    public class UserVm
    {
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; }
        public string  Password { get; set; }
        [StringLength(20,MinimumLength =4)]
        public string FirstName { get; set; }
        [StringLength(20, MinimumLength = 4)]
        public string  LastName { get; set; }
    }
}
