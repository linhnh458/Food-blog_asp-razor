using System;
using System.Collections.Generic;

namespace PRN221_Project_Blog.Models
{
    public partial class Video
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string YoutubeLink { get; set; } = null!;
        public string EmbeddedLink { get; set; } = null!;
        public string? Description { get; set; }
        public bool Status { get; set; }
    }
}
