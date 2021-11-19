using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.Cinemas
{
    public class DetailsModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public DetailsModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public Cinema Cinema { get; set; }

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cinema = await _context.Cinemas.FirstOrDefaultAsync(m => m.CinemaId == id);

            if (Cinema == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
