using System;
using System.Collections.Generic;

namespace PRN221_Project_Blog.Models
{
    public partial class Testimonial
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Job { get; set; }
        public string Content { get; set; } = null!;
        public bool Status { get; set; }
    }
}
