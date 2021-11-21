using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.MovieDirectors
{
    public class IndexModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public IndexModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public IList<Moviedirector> Moviedirector { get;set; }

        public async Task OnGetAsync()
        {
            Moviedirector = await _context.Moviedirectors
                .Include(m => m.DirectorDirector)
                .Include(m => m.MovieMovie).ToListAsync();
        }
    }
}
