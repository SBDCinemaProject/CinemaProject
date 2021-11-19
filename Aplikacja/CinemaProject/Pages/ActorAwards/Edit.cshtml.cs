using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.ActorAwards
{
    public class EditModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public EditModel(CinemaProject.Models.ModelContext context)
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
           ViewData["ActorActorId"] = new SelectList(_context.Actors, "ActorId", "Firstname");
           ViewData["AwardAwardId"] = new SelectList(_context.Awards, "AwardId", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Actoraward).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorawardExists(Actoraward.ActorActorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ActorawardExists(decimal id)
        {
            return _context.Actorawards.Any(e => e.ActorActorId == id);
        }
    }
}
