using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Languageversion
    {
        public Languageversion()
        {
            Screenings = new HashSet<Screening>();
        }
        [Required]
        public decimal LvId { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string Type { get; set; }

        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
