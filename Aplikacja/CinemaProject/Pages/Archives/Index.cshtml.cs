using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.Archives
{
    public class IndexModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public IndexModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public IList<Archive> Archive { get;set; }

        public async Task OnGetAsync()
        {
            Archive = await _context.Archives
                .Include(a => a.ScreeningScreening)
                .Include(a => a.UserUser).ToListAsync();
        }
    }
}
