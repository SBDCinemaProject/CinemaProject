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
    public class DetailsModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public DetailsModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public Directoraward Directoraward { get; set; }

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Directoraward = await _context.Directorawards
                .Include(d => d.AwardAward)
                .Include(d => d.DirectorDirector).FirstOrDefaultAsync(m => m.DirectorDirectorId == id);

            if (Directoraward == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
