using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Director
    {
        public Director()
        {
            Directorawards = new HashSet<Directoraward>();
            Moviedirectors = new HashSet<Moviedirector>();
        }
        [Required]
        public decimal DirectorId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public DateTime? Birthday { get; set; }
        public string Nationality { get; set; }

        public virtual ICollection<Directoraward> Directorawards { get; set; }
        public virtual ICollection<Moviedirector> Moviedirectors { get; set; }
    }
}
