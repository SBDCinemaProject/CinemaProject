using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;

namespace CinemaProject.Pages.Tickets
{
    public class DeleteModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public DeleteModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        public async Task<IActionResult> OnGetAsync(decimal? userId, decimal? screeningId)
        {
            if (userId == null || screeningId == null)
            {
                return NotFound();
            }

            Ticket = await _context.Tickets
                .Include(t => t.ScreeningScreening)
                .Include(t => t.UserUser)
                .Where(x => x.ScreeningScreeningId == screeningId && x.UserUserId == userId)
                .FirstOrDefaultAsync();

            if (Ticket == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(decimal? userId, decimal? screeningId)
        {
            if (userId == null || screeningId == null)
            {
                return NotFound();
            }

            Ticket = await _context.Tickets.FindAsync(userId, screeningId);

            if (Ticket != null)
            {
                _context.Tickets.Remove(Ticket);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Index");
        }
    }
}
