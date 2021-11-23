using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }
        [Required]
        public decimal GenreId { get; set; }
        [Required]
        [Display(Name="Genre Name")]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
