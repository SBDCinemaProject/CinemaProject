using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Article
    {
        [Required]
        public decimal ArticleId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime? Date { get; set; }
        [Required]
        public decimal WorkerWorkerId { get; set; }

        public virtual Worker WorkerWorker { get; set; }
    }
}
