using Microsoft.EntityFrameworkCore;
using Newsopedia.Data.Entities;
using System;

namespace Newsopedia.Data
{
    public class NewsopediaContext:DbContext
    {
        public NewsopediaContext(DbContextOptions<NewsopediaContext> options):base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<DateUrl> DateUrls { get; set; }
        
    }
}
