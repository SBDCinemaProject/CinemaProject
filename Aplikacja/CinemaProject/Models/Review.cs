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
        [MaxLength(1000)]
        public string Content { get; set; }
        [Required]
        [Range(0,10, ErrorMessage = "Rating must be a number from 0 to 10")]
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
