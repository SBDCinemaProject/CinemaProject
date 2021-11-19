using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaProject.Models;

namespace CinemaProject.Pages.ActorAwards
{
    public class CreateModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public CreateModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ActorActorId"] = new SelectList(_context.Actors, "ActorId", "Firstname");
        ViewData["AwardAwardId"] = new SelectList(_context.Awards, "AwardId", "Name");
            return Page();
        }

        [BindProperty]
        public Actoraward Actoraward { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Actorawards.Add(Actoraward);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
