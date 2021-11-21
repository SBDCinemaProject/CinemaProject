using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.Archives
{
    public class EditModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public EditModel(CinemaProject.Models.ModelContext context)
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
           ViewData["ScreeningScreeningId"] = new SelectList(_context.Screenings, "ScreeningId", "ScreeningId");
           ViewData["UserUserId"] = new SelectList(_context.Users, "UserId", "Email");
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

            _context.Attach(Archive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveExists(Archive.UserUserId))
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

        private bool ArchiveExists(decimal id)
        {
            return _context.Archives.Any(e => e.UserUserId == id);
        }
    }
}
