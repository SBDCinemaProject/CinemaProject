using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Review
    {
        [Required]
        public decimal ReviewId { get; set; }
        public string Content { get; set; }
        [Required]
        public byte Rating { get; set; }
        [Required]
        public decimal MovieMovieId { get; set; }
        [Required]
        public decimal UserUserId { get; set; }
        [Required]
        public DateTime Creationdate { get; set; }

        public virtual Movie MovieMovie { get; set; }
        public virtual User UserUser { get; set; }
    }
}
