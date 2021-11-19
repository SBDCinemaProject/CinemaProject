using System;
using System.Collections.Generic;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Movieactor
    {
        public decimal MovieMovieId { get; set; }
        public decimal ActorActorId { get; set; }
        public string Role { get; set; }

        public virtual Actor ActorActor { get; set; }
        public virtual Movie MovieMovie { get; set; }
    }
}
