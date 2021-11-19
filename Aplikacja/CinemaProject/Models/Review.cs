using System;
using System.Collections.Generic;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Review
    {
        public decimal ReviewId { get; set; }
        public string Content { get; set; }
        public byte Rating { get; set; }
        public decimal MovieMovieId { get; set; }
        public decimal UserUserId { get; set; }
        public DateTime Creationdate { get; set; }

        public virtual Movie MovieMovie { get; set; }
        public virtual User UserUser { get; set; }
    }
}
