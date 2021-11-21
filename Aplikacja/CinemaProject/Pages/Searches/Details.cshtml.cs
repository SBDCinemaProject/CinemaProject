using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.Searches
{
    public class DetailsModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public DetailsModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public Search Search { get; set; }

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Search = await _context.Searches
                .Include(s => s.UserUser).FirstOrDefaultAsync(m => m.SearchId == id);

            if (Search == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
