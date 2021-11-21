using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.Screenings
{
    public class DetailsModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public DetailsModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public Screening Screening { get; set; }

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Screening = await _context.Screenings
                .Include(s => s.LanguageversionLv)
                .Include(s => s.MovieMovie)
                .Include(s => s.RoomRoom).FirstOrDefaultAsync(m => m.ScreeningId == id);

            if (Screening == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
