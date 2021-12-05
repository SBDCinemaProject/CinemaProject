using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.Actors
{
    public class ActorsInMovieModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public ActorsInMovieModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public IList<Movieactor> MovieActors { get;set; }

        public async Task<ActionResult> OnGetAsync(decimal? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            MovieActors = await _context.Movieactors
                          .Include(x => x.ActorActor)
                          .Include(x => x.MovieMovie)
                          .Where(x => x.MovieMovieId == id)
                          .ToListAsync();
            return Page();
        }
    }
}
