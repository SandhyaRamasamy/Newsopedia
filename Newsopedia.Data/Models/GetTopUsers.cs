using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Newsopedia.Data.Models
{
    [Keyless]
    public class GetTopUsers
    {

        //[Key]
        //public int UserId { get; set; }
        //public int JunctionUserId { get; set; }
        //public int Total { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
                
    }
}
