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
    public class DeleteModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public DeleteModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Directoraward = await _context.Directorawards.FindAsync(id);

            if (Directoraward != null)
            {
                _context.Directorawards.Remove(Directoraward);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
