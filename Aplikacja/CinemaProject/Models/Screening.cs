using System;
using System.Collections.Generic;

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

        public decimal ScreeningId { get; set; }
        public decimal MovieMovieId { get; set; }
        public decimal RoomRoomId { get; set; }
        public decimal? Price { get; set; }
        public decimal LanguageversionLvId { get; set; }

        public virtual Languageversion LanguageversionLv { get; set; }
        public virtual Movie MovieMovie { get; set; }
        public virtual Room RoomRoom { get; set; }
        public virtual ICollection<Archive> Archives { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
