using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Worker
    {
        public Worker()
        {
            Articles = new HashSet<Article>();
        }
        [Required]
        public decimal CinemaCinemaId { get; set; }
        [Required]
        public decimal WorkerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual Cinema CinemaCinema { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
