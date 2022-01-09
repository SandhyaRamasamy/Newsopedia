using System;
using System.Collections.Generic;

#nullable disable

namespace Newsopedia.Data.Models
{
    public partial class NewsTable
    {
        public NewsTable()
        {
            UserNewsTables = new HashSet<UserNewsTable>();
        }

        public int NewsId { get; set; }
        public string NewsUrl { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDescription { get; set; }
        public string NewsImageUrl { get; set; }
        


        public virtual ICollection<UserNewsTable> UserNewsTables { get; set; }
    }
}
