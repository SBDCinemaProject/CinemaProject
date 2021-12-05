using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaProject.Models;

namespace CinemaProject.Pages.LanguageVersions
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
        public Languageversion Languageversion { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //Find last id
            if (_context.Languageversions.Count() != 0)
            {
                decimal id = _context.Languageversions
                .Select(x => x.LvId)
                .Max();
                Languageversion.LvId = id + 1;
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Languageversions.Add(Languageversion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
