using System;
using System.Collections.Generic;
using System.Text;

namespace Newsopedia.Data.Models
{
    public class NewsArticle
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string UserEmail { get; set; }
        public string Description { get; set; }
        public string UrlToImage { get; set; }
    }
}
