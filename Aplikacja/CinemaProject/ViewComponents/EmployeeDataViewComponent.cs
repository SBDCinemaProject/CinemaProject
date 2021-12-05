using CinemaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.ViewComponents
{
    public class EmployeeDataViewComponent : ViewComponent
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public EmployeeDataViewComponent(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }
        public Worker Worker { get; set; }
        public IViewComponentResult Invoke(decimal? id)
        {
            if (id == null)
                return null;
            ViewData["CinemaCinemaId"] = new SelectList(_context.Cinemas, "CinemaId", "City");
            Worker = _context.Workers
                       .Where(x => x.WorkerId == id)
                       .FirstOrDefault();
            return View(Worker);
        }
    }
}

