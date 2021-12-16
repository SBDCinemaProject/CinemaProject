using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace CinemaProject.Models
{
    public partial class Ticket
    {
        [Required]
        public decimal UserUserId { get; set; }
        [Required]
        public decimal ScreeningScreeningId { get; set; }
        [Required]
        [BindProperty,DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public virtual Screening ScreeningScreening { get; set; }
        public virtual User UserUser { get; set; }
    }
}
