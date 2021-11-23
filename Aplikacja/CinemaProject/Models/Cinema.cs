using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Cinema
    {
        public Cinema()
        {
            Rooms = new HashSet<Room>();
            Workers = new HashSet<Worker>();
        }
        [Required]
        public decimal CinemaId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Display(Name = "Cinema Name")]
        public string Name { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
