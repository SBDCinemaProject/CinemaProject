using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages
{
    public class SearchPageModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public SearchPageModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string selectedValue { get; set; }
        public Movie Movie { get; set; }
        public ActionResult OnGet(string search)
        {
            if (selectedValue == null)
            {
                return NotFound();
            }
            switch (selectedValue)
            {
                case "movie":
                    return RedirectToPage("/Movies/MovieSearchPage", new { search = search});
                case "screening":
                    return RedirectToPage("/Screenings/ScreeningSearchPage", new { search = search });
                case "actor":
                    return RedirectToPage("/Actors/ActorSearchPage", new { search = search });
                case "director":
                    return RedirectToPage("/Directors/DirectorSearchPage", new { search = search });
            }
            return Page();
        }

    }
}
