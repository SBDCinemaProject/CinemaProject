using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.MovieActors
{
    public class EditModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public EditModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movieactor Movieactor { get; set; }

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movieactor = await _context.Movieactors
                .Include(m => m.ActorActor)
                .Include(m => m.MovieMovie).FirstOrDefaultAsync(m => m.MovieMovieId == id);

            if (Movieactor == null)
            {
                return NotFound();
            }
           ViewData["ActorActorId"] = new SelectList(_context.Actors, "ActorId", "Firstname");
           ViewData["MovieMovieId"] = new SelectList(_context.Movies, "MovieId", "Name");
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

            _context.Attach(Movieactor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieactorExists(Movieactor.MovieMovieId))
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

        private bool MovieactorExists(decimal id)
        {
            return _context.Movieactors.Any(e => e.MovieMovieId == id);
        }
    }
}
