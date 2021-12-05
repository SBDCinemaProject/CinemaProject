using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaProject.Models;

namespace CinemaProject.Pages.Articles
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
        ViewData["WorkerWorkerId"] = new SelectList(_context.Workers, "WorkerId", "Name");
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Article.Date = DateTime.Now;
            //Find last id
            if (_context.Articles.Count() != 0)
            {
                decimal id = _context.Articles
                .Select(x => x.ArticleId)
                .Max();
                Article.ArticleId = id + 1;
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Articles.Add(Article);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
