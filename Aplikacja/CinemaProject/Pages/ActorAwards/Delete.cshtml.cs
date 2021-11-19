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

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actoraward = await _context.Actorawards
                .Include(a => a.ActorActor)
                .Include(a => a.AwardAward).FirstOrDefaultAsync(m => m.ActorActorId == id);

            if (Actoraward == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actoraward = await _context.Actorawards.FindAsync(id);

            if (Actoraward != null)
            {
                _context.Actorawards.Remove(Actoraward);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
