using System;
using System.Collections.Generic;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Moviedirector
    {
        public decimal MovieMovieId { get; set; }
        public decimal DirectorDirectorId { get; set; }

        public virtual Director DirectorDirector { get; set; }
        public virtual Movie MovieMovie { get; set; }
    }
}
