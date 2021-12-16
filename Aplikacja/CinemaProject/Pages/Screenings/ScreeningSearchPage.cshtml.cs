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
    public class ScreeningSearchPageModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;
        public ScreeningSearchPageModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }
        public List<Screening> Screenings { get; set; }
        public ActionResult OnGet(string search)
        {
            if (search != null)
                search = search.ToLower();
            Screenings = _context.Screenings
                    .Where(x => x.MovieMovie.Name.ToLower().Contains(search))
                    .Include(x => x.MovieMovie)
                    .Include(x => x.RoomRoom)
                    .Include(x => x.LanguageversionLv)
                    .ToList();
            return Page();
        }
    }
}
