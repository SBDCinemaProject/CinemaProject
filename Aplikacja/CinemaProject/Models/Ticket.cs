using System;
using System.Collections.Generic;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Ticket
    {
        public decimal UserUserId { get; set; }
        public decimal ScreeningScreeningId { get; set; }
        public DateTime Date { get; set; }

        public virtual Screening ScreeningScreening { get; set; }
        public virtual User UserUser { get; set; }
    }
}
