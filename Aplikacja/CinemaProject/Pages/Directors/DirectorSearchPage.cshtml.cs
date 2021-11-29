using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Directors
{
    public class DirectorSearchPageModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;
        public DirectorSearchPageModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }
        public List<Director> Directors { get; set; }
        public ActionResult OnGet(string search)
        {
            if (search != null)
                search = search.ToLower();
            Directors = _context.Directors
                        .Where(x => x.Firstname.ToLower().Contains(search) || x.Lastname.ToLower().Contains(search))
                        .ToList();
            return Page();
        }
    }
}
