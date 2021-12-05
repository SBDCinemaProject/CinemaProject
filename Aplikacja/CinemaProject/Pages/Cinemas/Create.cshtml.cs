using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaProject.Models;

namespace CinemaProject.Pages.Cinemas
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
            return Page();
        }

        [BindProperty]
        public Cinema Cinema { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //Find last id
            if (_context.Cinemas.Count() != 0)
            {
                decimal id = _context.Cinemas
                .Select(x => x.CinemaId)
                .Max();
                Cinema.CinemaId = id + 1;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cinemas.Add(Cinema);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
