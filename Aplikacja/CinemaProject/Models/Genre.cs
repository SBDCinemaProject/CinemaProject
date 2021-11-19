using System;
using System.Collections.Generic;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public decimal GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
