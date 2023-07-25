using System;
using System.Collections.Generic;

namespace PRN221_Project_Blog.Models
{
    public partial class User
    {
        public User()
        {
            Blogs = new HashSet<Blog>();
            Tips = new HashSet<Tip>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int UserRoleId { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Tip> Tips { get; set; }
    }
}
