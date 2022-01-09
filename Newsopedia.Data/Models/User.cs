using System;
using System.Collections.Generic;

#nullable disable

namespace Newsopedia.Data.Models
{
    public partial class User
    {
        public User()
        {
            UserNewsTables = new HashSet<UserNewsTable>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<UserNewsTable> UserNewsTables { get; set; }
    }
}
