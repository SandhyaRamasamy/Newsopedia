using System;
using System.Collections.Generic;
using System.Text;

namespace Newsopedia.Services.Models
{
    public class DateUrlVm
    {
        public int DateUrlIDVm{ get; set; }
        public UserVm UserIDVm { get; set; }
        public string DateVm { get; set; }
        public string NewsUrlVm { get; set; }
        public string NewsTitleVm { get; set; }
        public string NewsDescriptionvM { get; set; }
        public string NewsImageURLVm { get; set; }
    }
}
