using System;
using System.Collections.Generic;
using System.Text;

namespace Newsopedia.Data.Entities
{
    public class NewsArticle
    {
        public string  Title{ get; set; }
        public string URL { get; set; }
        public string UserEmail { get; set; }
        public string Description { get; set; }
        public string URLToImage { get; set; }
    }
}
