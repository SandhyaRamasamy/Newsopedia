using System;
using System.Collections.Generic;
using System.Text;

namespace Newsopedia.Services.NewsopediaOldModels
{
    public class UserNewsVm
    {
        public int Id { get; set; }
        public int UserNewsId { get; set; }
        public int UserId { get; set; }
        public int NewsId { get; set; }
        public string Date { get; set; }
    }
}
