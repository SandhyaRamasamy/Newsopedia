using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Newsopedia.Services.Models
{
    public class UserVm
    {
        
        public int UserIdVm { get; set; }
        [Required]
        
        public string EmailVm { get; set; }
     
        public string  PasswordVm { get; set; }
        [StringLength(20,MinimumLength =4)]
        public string FirstNameVm { get; set; }
        [StringLength(20, MinimumLength = 4)]
        public string  LastNameVm { get; set; }
    }
}
