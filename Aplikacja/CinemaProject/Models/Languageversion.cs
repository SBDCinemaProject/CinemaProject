using System;
using System.Collections.Generic;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Languageversion
    {
        public Languageversion()
        {
            Screenings = new HashSet<Screening>();
        }

        public decimal LvId { get; set; }
        public string Language { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
