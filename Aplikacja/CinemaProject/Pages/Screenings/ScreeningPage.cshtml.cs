using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CinemaProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

        public User ThisUser { get; set; }


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

        public IActionResult OnPost(decimal? id)
        {
            Screening = _context.Screenings
                        .Include(m => m.LanguageversionLv)
                        .Include(m => m.MovieMovie).ThenInclude(n => n.GenreGenre)
                        .Include(m => m.RoomRoom).ThenInclude(n => n.CinemaCinema)
                        .FirstOrDefault(m => m.ScreeningId == id);

            decimal userId = decimal.Parse(User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                   .Select(c => c.Value).SingleOrDefault());

            ThisUser = _context.Users
               .Include(x => x.Tickets).ThenInclude(y => y.ScreeningScreening).ThenInclude(z => z.MovieMovie)
               .Where(x => x.UserId == userId)
               .FirstOrDefault();


            if (ModelState.IsValid)
            { 
                HttpContext.Session.SetString("Screening", JsonConvert.SerializeObject(Screening,Formatting.Indented,
new JsonSerializerSettings
{
    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
}));
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(ThisUser, Formatting.Indented,
new JsonSerializerSettings
{
    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
}));
                return RedirectToPage("../Tickets/BuyTicket");
            }
            return Page();
        }

    }
}
