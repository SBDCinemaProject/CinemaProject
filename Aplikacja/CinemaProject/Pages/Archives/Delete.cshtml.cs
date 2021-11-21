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
    public class DeleteModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public DeleteModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Archive Archive { get; set; }

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Archive = await _context.Archives
                .Include(a => a.ScreeningScreening)
                .Include(a => a.UserUser).FirstOrDefaultAsync(m => m.UserUserId == id);

            if (Archive == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Archive = await _context.Archives.FindAsync(id);

            if (Archive != null)
            {
                _context.Archives.Remove(Archive);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
