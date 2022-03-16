﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Newsopedia.Services.Models
{
    public class NewsArticleVm
    {
        public string Title{ get; set; }
        public string Url { get; set; }
        public string UserEmail { get; set; }
        public string Description { get; set; }
        public string UrlToImage { get; set; }
    }
}
