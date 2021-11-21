using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.MovieDirectors
{
    public class DetailsModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public DetailsModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public Moviedirector Moviedirector { get; set; }

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Moviedirector = await _context.Moviedirectors
                .Include(m => m.DirectorDirector)
                .Include(m => m.MovieMovie).FirstOrDefaultAsync(m => m.MovieMovieId == id);

            if (Moviedirector == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
