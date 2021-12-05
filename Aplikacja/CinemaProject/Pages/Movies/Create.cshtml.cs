using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaProject.Models;

namespace CinemaProject.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public CreateModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GenreGenreId"] = new SelectList(_context.Genres, "GenreId", "Name");
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //Find last id
            if (_context.Movies.Count() != 0)
            {
                decimal id = _context.Movies
                .Select(x => x.MovieId)
                .Max();
                Movie.MovieId = id + 1;
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
