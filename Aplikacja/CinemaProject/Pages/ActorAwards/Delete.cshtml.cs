using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.ActorAwards
{
    public class DeleteModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public DeleteModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Actoraward Actoraward { get; set; }

        public async Task<IActionResult> OnGetAsync(decimal? actorId, decimal? awardId)
        {
            if (actorId == null || awardId == null)
            {
                return NotFound();
            }

            Actoraward = await _context.Actorawards
                .Include(a => a.ActorActor).Where(m => m.ActorActorId == actorId)
                .Include(a => a.AwardAward).Where(m => m.AwardAwardId == awardId)
                .FirstOrDefaultAsync();

            if (Actoraward == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(decimal? actorId, decimal? awardId)
        {
            if (actorId == null || awardId == null)
            {
                return NotFound();
            }

            Actoraward = await _context.Actorawards.FindAsync(actorId, awardId);

            if (Actoraward != null)
            {
                _context.Actorawards.Remove(Actoraward);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
