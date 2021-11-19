using System;
using System.Collections.Generic;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Room
    {
        public Room()
        {
            Screenings = new HashSet<Screening>();
        }

        public decimal RoomId { get; set; }
        public string Name { get; set; }
        public decimal Capacity { get; set; }
        public decimal CinemaCinemaId { get; set; }
        public string IsAvalible { get; set; }

        public virtual Cinema CinemaCinema { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
