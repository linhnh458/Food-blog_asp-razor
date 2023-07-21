using System;
using System.Collections.Generic;

namespace PRN221_Project_Blog.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string Content { get; set; } = null!;
        public int? CategoryId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int AuthorId { get; set; }

        public virtual User Author { get; set; } = null!;
        public virtual Category? Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
