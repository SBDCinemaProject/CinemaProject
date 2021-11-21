using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.Reviews
{
    public class EditModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public EditModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; }

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Review = await _context.Reviews
                .Include(r => r.MovieMovie)
                .Include(r => r.UserUser).FirstOrDefaultAsync(m => m.ReviewId == id);

            if (Review == null)
            {
                return NotFound();
            }
           ViewData["MovieMovieId"] = new SelectList(_context.Movies, "MovieId", "Name");
           ViewData["UserUserId"] = new SelectList(_context.Users, "UserId", "Email");
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

            _context.Attach(Review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(Review.ReviewId))
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

        private bool ReviewExists(decimal id)
        {
            return _context.Reviews.Any(e => e.ReviewId == id);
        }
    }
}
