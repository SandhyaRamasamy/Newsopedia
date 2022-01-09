using System;
using System.Collections.Generic;
using System.Text;

namespace Newsopedia.Data.Models
{
    public class ConcatenatedTable
    {
        public int UserId { get; set; }
        public int NewsId { get; set; }
        public int  UserNewsId{ get; set; }
        public string Date { get; set; }
        public string NewsUrl { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDescription { get; set; }
        public string NewsImageUrl { get; set; }
    }
}
