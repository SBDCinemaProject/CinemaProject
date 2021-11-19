using System;
using System.Collections.Generic;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Search
    {
        public decimal SearchId { get; set; }
        public string Content { get; set; }
        public decimal UserUserId { get; set; }
        public string Category { get; set; }

        public virtual User UserUser { get; set; }
    }
}
