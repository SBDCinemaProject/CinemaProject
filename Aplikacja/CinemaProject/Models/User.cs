using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CinemaProject.Models
{
    public partial class User
    {
        public User()
        {
            Archives = new HashSet<Archive>();
            Reviews = new HashSet<Review>();
            Searches = new HashSet<Search>();
            Tickets = new HashSet<Ticket>();
        }
        [Required]
        public decimal UserId { get; set; }
        [Required]
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public virtual ICollection<Archive> Archives { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Search> Searches { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
