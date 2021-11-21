using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.DirectorAwards
{
    public class EditModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public EditModel(CinemaProject.Models.ModelContext context)
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
           ViewData["AwardAwardId"] = new SelectList(_context.Awards, "AwardId", "Name");
           ViewData["DirectorDirectorId"] = new SelectList(_context.Directors, "DirectorId", "Firstname");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Directoraward).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorawardExists(Directoraward.DirectorDirectorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DirectorawardExists(decimal id)
        {
            return _context.Directorawards.Any(e => e.DirectorDirectorId == id);
        }
    }
}
