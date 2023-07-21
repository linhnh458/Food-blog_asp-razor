﻿using System;
using System.Collections.Generic;

namespace PRN221_Project_Blog.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Role1 { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
