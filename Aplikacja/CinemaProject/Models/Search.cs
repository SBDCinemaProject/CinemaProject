using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Search
    {
        [Required]
        public decimal SearchId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public decimal UserUserId { get; set; }
        public string Category { get; set; }

        public virtual User UserUser { get; set; }
    }
}
