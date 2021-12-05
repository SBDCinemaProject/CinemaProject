using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaProject.Models;

namespace CinemaProject.Pages.Screenings
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
        ViewData["LanguageversionLvId"] = new SelectList(_context.Languageversions, "LvId", "Language");
        ViewData["MovieMovieId"] = new SelectList(_context.Movies, "MovieId", "Name");
        ViewData["RoomRoomId"] = new SelectList(_context.Rooms, "RoomId", "IsAvalible");
            return Page();
        }

        [BindProperty]
        public Screening Screening { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //Find last id
            if (_context.Screenings.Count() != 0)
            {
                decimal id = _context.Screenings
                .Select(x => x.ScreeningId)
                .Max();
                Screening.ScreeningId = id + 1;
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Screenings.Add(Screening);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
