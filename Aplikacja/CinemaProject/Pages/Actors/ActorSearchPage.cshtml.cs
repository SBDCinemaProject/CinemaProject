using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Actors
{
    public class ActorSearchPageModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;
        public ActorSearchPageModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }
        public List<Actor> Actors { get; set; }
        public ActionResult OnGet(string search)
        {
            if (search != null)
                search = search.ToLower();
            Actors = _context.Actors
                   .Where(x => x.Firstname.ToLower().Contains(search) || x.Lastname.ToLower().Contains(search))
                   .ToList();
            return Page();
        }
    }
}
