using System;
using System.Collections.Generic;

namespace PRN221_Project_Blog.Models
{
    public partial class Category
    {
        public Category()
        {
            Blogs = new HashSet<Blog>();
            Tips = new HashSet<Tip>();
        }

        public int Id { get; set; }
        public string Category1 { get; set; } = null!;

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Tip> Tips { get; set; }
    }
}
