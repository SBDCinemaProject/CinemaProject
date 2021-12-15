using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Pages.Screenings
{
    public class ScreeningPageModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public ScreeningPageModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;           
        }
        public Screening Screening { get; set; }

        [BindProperty]
        public Ticket Ticket { get; set; }

        public List<Screening> ScreeningDifferentLanguageVersions { get; set; }
        public ActionResult OnGet(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Screening = _context.Screenings
                        .Include(m => m.LanguageversionLv)
                        .Include(m => m.MovieMovie).ThenInclude(n => n.GenreGenre)
                        .Include(m => m.RoomRoom).ThenInclude(n => n.CinemaCinema)
                        .FirstOrDefault(m => m.ScreeningId == id);

            if (Screening.MovieMovie == null)
                return NotFound();

            ScreeningDifferentLanguageVersions = _context.Screenings
                                                .Include(m => m.LanguageversionLv)
                                                .Where(m => m.MovieMovieId == Screening.MovieMovieId && m.LanguageversionLvId != Screening.LanguageversionLvId)
                                                .ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostCreateTicket()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tickets.Add(Ticket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        
    }
}
