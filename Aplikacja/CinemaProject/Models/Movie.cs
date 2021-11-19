using System;
using System.Collections.Generic;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Movieactors = new HashSet<Movieactor>();
            Moviedirectors = new HashSet<Moviedirector>();
            Reviews = new HashSet<Review>();
            Screenings = new HashSet<Screening>();
        }

        public decimal MovieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Productionyear { get; set; }
        public decimal GenreGenreId { get; set; }
        public string Country { get; set; }

        public virtual Genre GenreGenre { get; set; }
        public virtual ICollection<Movieactor> Movieactors { get; set; }
        public virtual ICollection<Moviedirector> Moviedirectors { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
