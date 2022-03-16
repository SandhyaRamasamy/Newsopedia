using System;
using System.Collections.Generic;
using System.Text;

namespace Newsopedia.Services.Models
{
    public class DateUrlVm
    {
        public int DateUrlId{ get; set; }
        public UserVm UserId { get; set; }
        public string Date { get; set; }
        public string NewsUrl { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDescription { get; set; }
        public string NewsImageUrl { get; set; }
    }
}
