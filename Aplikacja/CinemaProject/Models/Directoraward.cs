using System;
using System.Collections.Generic;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Directoraward
    {
        public decimal DirectorDirectorId { get; set; }
        public decimal AwardAwardId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Award AwardAward { get; set; }
        public virtual Director DirectorDirector { get; set; }
    }
}
