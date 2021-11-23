using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Room
    {
        public Room()
        {
            Screenings = new HashSet<Screening>();
        }
        [Required]
        public decimal RoomId { get; set; }
        [Required]
        [Display(Name = "Room Name")]
        public string Name { get; set; }
        [Required]
        public decimal Capacity { get; set; }
        [Required]
        public decimal CinemaCinemaId { get; set; }
        [Required]
        public string IsAvalible { get; set; }

        public virtual Cinema CinemaCinema { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
