using System;
using System.Collections.Generic;

namespace PRN221_Project_Blog.Models
{
    public partial class Tip
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int AuthorId { get; set; }

        public virtual User Author { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
}
