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
    public class IndexModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public IndexModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public IList<Actor> Actor { get;set; }

        public async Task OnGetAsync()
        {
            Actor = await _context.Actors.ToListAsync();
        }
    }
}
