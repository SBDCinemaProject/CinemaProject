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
    public class ScreeningsOfMovieModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public ScreeningsOfMovieModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public IList<Screening> Screenings { get;set; }

        public async Task<ActionResult> OnGetAsync(decimal? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Screenings = await _context.Screenings
                .Include(s => s.LanguageversionLv)
                .Include(s => s.MovieMovie)
                .Include(s => s.RoomRoom).ToListAsync();
            return Page();
        }
    }
}
