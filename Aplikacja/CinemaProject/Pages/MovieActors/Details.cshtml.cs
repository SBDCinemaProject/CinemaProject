using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.MovieActors
{
    public class DetailsModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public DetailsModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
