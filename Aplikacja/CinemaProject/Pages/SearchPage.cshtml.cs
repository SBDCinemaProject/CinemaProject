using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            if(User.Identity.IsAuthenticated)
            {
                //get id of current user by checking his claim
                decimal userId = decimal.Parse(User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                   .Select(c => c.Value).SingleOrDefault());
                Search searchDatabase = new Search()
                {
                    Content = search ?? " ",
                    Category = selectedValue,
                    UserUserId = userId,
                };
                //Find last id
                if (_context.Searches.Count() != 0)
                {
                    decimal id = _context.Searches
                    .Select(x => x.SearchId)
                    .Max();
                    searchDatabase.SearchId = id + 1;
                    
                }
                _context.Add(searchDatabase);
                _context.SaveChanges();
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
