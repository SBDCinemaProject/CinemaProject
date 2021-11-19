using System;
using System.Collections.Generic;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Article
    {
        public decimal ArticleId { get; set; }
        public string Content { get; set; }
        public DateTime? Date { get; set; }
        public decimal WorkerWorkerId { get; set; }

        public virtual Worker WorkerWorker { get; set; }
    }
}
