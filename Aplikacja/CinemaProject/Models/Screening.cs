using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Screening
    {
        public Screening()
        {
            Archives = new HashSet<Archive>();
            Tickets = new HashSet<Ticket>();
        }
        [Required]
        public decimal ScreeningId { get; set; }
        [Required]
        public decimal MovieMovieId { get; set; }
        [Required]
        public decimal RoomRoomId { get; set; }
        public decimal? Price { get; set; }
        [Required]
        public decimal LanguageversionLvId { get; set; }

        public virtual Languageversion LanguageversionLv { get; set; }
        public virtual Movie MovieMovie { get; set; }
        public virtual Room RoomRoom { get; set; }
        public virtual ICollection<Archive> Archives { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
