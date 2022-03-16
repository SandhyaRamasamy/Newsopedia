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
        public string FirstName { get; set; }
        public string LastName { get; set; }               
    }
}
