using CinemaProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.Pages.Components
{
    public class SearchListViewComponent : ViewComponent
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public SearchListViewComponent(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }
        List<Search> Searches { get; set; }
        public IViewComponentResult Invoke(decimal? id)
        {
            if (id == null)
                return null;
            Searches = _context.Searches
                       .Where(x => x.UserUserId == id)
                       .ToList();
            return View(Searches);
        }
    }
}
