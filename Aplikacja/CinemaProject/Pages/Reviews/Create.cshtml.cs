using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaProject.Models;

namespace CinemaProject.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public CreateModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(decimal? movieId, decimal? userId)
        {
            if(movieId == null || userId == null)
            {
                return NotFound();
            }
            ViewData["MovieName"] = _context.Movies.Where(x => x.MovieId == movieId).Select(x => x.Name).FirstOrDefault().ToString();
            ViewData["Username"] = _context.Users.Where(x => x.UserId == userId).Select(x => x.Username).FirstOrDefault().ToString();
            ViewData["MovieID"] = movieId;
            ViewData["UserId"] = userId;
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            bool isInDatabase = _context.Reviews.Any(x => x.UserUserId == Review.UserUserId && x.MovieMovieId == Review.MovieMovieId);
            if(isInDatabase)
            {
                ModelState.AddModelError("isInDatabase", "You have already posted review");
                return Page();
            }
            //Find last id
            if (_context.Reviews.Count() != 0)
            {
                decimal id = _context.Reviews
                .Select(x => x.ReviewId)
                .Max();
                Review.ReviewId = id + 1;
            }
            Review.Creationdate = DateTime.Now;
            ModelState.Clear();
            TryValidateModel(Review);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Movies/MoviePage", new { id = Review.MovieMovieId });
        }
    }
}
