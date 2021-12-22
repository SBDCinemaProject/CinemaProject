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
    public class DeleteModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public DeleteModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; }

        public async Task<IActionResult> OnGetAsync(decimal? movieId, decimal? userId)
        {
            if (movieId == null || userId == null)
            {
                return NotFound();
            }

            Review = await _context.Reviews
                .Where(m => m.MovieMovieId == movieId && m.UserUserId == userId)
                .Include(r => r.MovieMovie)
                .Include(r => r.UserUser)
                .FirstOrDefaultAsync();

            if (Review == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(decimal? movieId, decimal? userId)
        {
            if (movieId == null || userId == null)
            {
                return NotFound();
            }

            Review = await _context.Reviews.Where(x => x.UserUserId == userId && x.MovieMovieId == movieId).FirstOrDefaultAsync();

            if (Review != null)
            {
                _context.Reviews.Remove(Review);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Movies/MoviePage", new { id = movieId});
        }
    }
}
