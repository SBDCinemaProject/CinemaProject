using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.Reviews
{
    public class ReviewsOfMovieModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public ReviewsOfMovieModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public IList<Review> Reviews { get;set; }

        public async Task<ActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Reviews = await _context.Reviews
                .Include(r => r.MovieMovie)
                .Include(r => r.UserUser)
                .Where(x => x.MovieMovieId == id)
                .ToListAsync();
            return Page();
        }
    }
}
