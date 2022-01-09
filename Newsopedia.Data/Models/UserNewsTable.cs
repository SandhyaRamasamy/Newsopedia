using System;
using System.Collections.Generic;

#nullable disable

namespace Newsopedia.Data.Models
{
    public partial class UserNewsTable
    {
        public int UserNewsId { get; set; }
        public int UserId { get; set; }
        public int NewsId { get; set; }
        public string Date { get; set; }

        public virtual NewsTable News { get; set; }
        public virtual User User { get; set; }
    }
}
