using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Actor
    {
        public Actor()
        {
            Actorawards = new HashSet<Actoraward>();
            Movieactors = new HashSet<Movieactor>();
        }
        [Required]
        public decimal ActorId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public DateTime? Birthday { get; set; }
        public string Nationality { get; set; }

        public virtual ICollection<Actoraward> Actorawards { get; set; }
        public virtual ICollection<Movieactor> Movieactors { get; set; }
    }
}
