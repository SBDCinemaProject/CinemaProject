using CinemaProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.ViewComponents
{
    public class EmployeeDatabaseViewComponent : ViewComponent
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public EmployeeDatabaseViewComponent(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }
        public Worker Worker { get; set; }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
