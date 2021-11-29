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
    public class MovieSearchPageModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;
        public MovieSearchPageModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }
        public List<Movie> Movies { get; set; }
        public ActionResult OnGet(string search)
        {   
            if(search != null)
                search = search.ToLower();
            Movies = _context.Movies
                    .Where(x => x.Name.ToLower().Contains(search))
                    .Include(x => x.GenreGenre)
                    .ToList();
            return Page();
        }
    }
}
