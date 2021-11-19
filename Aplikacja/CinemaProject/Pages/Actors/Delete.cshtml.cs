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
    public class DeleteModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public DeleteModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Actor Actor { get; set; }

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actor = await _context.Actors.FirstOrDefaultAsync(m => m.ActorId == id);

            if (Actor == null)
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

            Actor = await _context.Actors.FindAsync(id);

            if (Actor != null)
            {
                _context.Actors.Remove(Actor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
