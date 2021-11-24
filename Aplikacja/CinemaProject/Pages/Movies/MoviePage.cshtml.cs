using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Pages.Movies
{
    public class MoviePageModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public MoviePageModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }
        public Movie Movie { get; set; }
        public ActionResult OnGet(decimal? id)
        {          
            if (id == null)
            {
                return NotFound();
            }
            //Load movie having particular id with all related information
            Movie = _context.Movies
                    .Include(m => m.GenreGenre)
                    .Include(m => m.Reviews).ThenInclude(n => n.UserUser)
                    .Include(m => m.Screenings.OrderBy(p => p.Price)).ThenInclude(n => n.RoomRoom).ThenInclude(o => o.CinemaCinema)
                    .Include(m => m.Movieactors).ThenInclude(n => n.ActorActor)
                    .Include(m => m.Moviedirectors).ThenInclude(n => n.DirectorDirector)
                    .FirstOrDefault(m => m.MovieId == id);
            Movie.Screenings = Movie.Screenings.Take(4).ToList();
            Movie.Movieactors = Movie.Movieactors.Take(4).ToList();
            Movie.Screenings = Movie.Screenings.Take(4).ToList();

            decimal sum = Movie.Reviews.Sum(x => x.Rating);
            ViewData["raiting"] = sum / Movie.Reviews.Count;

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
