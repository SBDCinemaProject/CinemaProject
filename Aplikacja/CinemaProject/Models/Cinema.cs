using System;
using System.Collections.Generic;

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

        public decimal CinemaId { get; set; }
        public string City { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
