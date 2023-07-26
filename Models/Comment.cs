using System;
using System.Collections.Generic;

namespace PRN221_Project_Blog.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string Content { get; set; } = null!;
        public int User { get; set; }

        public virtual Blog Blog { get; set; } = null!;
        public virtual User UserNavigation { get; set; } = null!;
    }
}
