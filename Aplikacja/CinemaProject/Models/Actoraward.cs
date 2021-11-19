using System;
using System.Collections.Generic;

#nullable disable

namespace CinemaProject.Models
{
    public partial class Actoraward
    {
        public decimal ActorActorId { get; set; }
        public decimal AwardAwardId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Actor ActorActor { get; set; }
        public virtual Award AwardAward { get; set; }
    }
}
