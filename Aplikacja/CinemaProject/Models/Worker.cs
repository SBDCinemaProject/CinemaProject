using System;
using System.Collections.Generic;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Worker
    {
        public Worker()
        {
            Articles = new HashSet<Article>();
        }

        public decimal CinemaCinemaId { get; set; }
        public decimal WorkerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Salary { get; set; }
        public string Position { get; set; }
        public string Password { get; set; }

        public virtual Cinema CinemaCinema { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
