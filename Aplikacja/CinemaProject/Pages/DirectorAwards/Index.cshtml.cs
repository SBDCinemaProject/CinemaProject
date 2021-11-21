using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.DirectorAwards
{
    public class IndexModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public IndexModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public IList<Directoraward> Directoraward { get;set; }

        public async Task OnGetAsync()
        {
            Directoraward = await _context.Directorawards
                .Include(d => d.AwardAward)
                .Include(d => d.DirectorDirector).ToListAsync();
        }
    }
}
