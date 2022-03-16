using System;
using System.Collections.Generic;
using System.Text;

namespace Newsopedia.Services.NewsopediaOldModels
{
    public class NewsTableVm
    {
        public int NewsId { get; set; }
        public string NewsUrl { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDescription { get; set; }
        public string NewsImageUrl { get; set; }        
    }
}
