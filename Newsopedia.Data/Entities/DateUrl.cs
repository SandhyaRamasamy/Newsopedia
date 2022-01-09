using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Newsopedia.Data.Entities
{
    public class DateUrl
    { 
        [Key]
        public int DateUrlID { get; set; }
        public User UserID { get; set; }
        public string Date { get; set; }
        public string NewsUrl { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDescription { get; set; }
        public string NewsImageURL { get; set; }

    }
}
