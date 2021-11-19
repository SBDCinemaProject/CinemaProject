using System;
using System.Collections.Generic;

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

        public decimal UserId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Archive> Archives { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Search> Searches { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
