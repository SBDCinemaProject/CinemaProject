using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Award
    {
        public Award()
        {
            Actorawards = new HashSet<Actoraward>();
            Directorawards = new HashSet<Directoraward>();
        }
        [Required]
        public decimal AwardId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Actoraward> Actorawards { get; set; }
        public virtual ICollection<Directoraward> Directorawards { get; set; }
    }
}
