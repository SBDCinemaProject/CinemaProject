using CinemaProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.ViewComponents
{
    public class UserDataViewComponent : ViewComponent
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public UserDataViewComponent(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }
        public User ThisUser { get; set; }
        public IViewComponentResult Invoke(decimal? id)
        {
            if (id == null)
                return null;
            ThisUser = _context.Users
                       .Where(x => x.UserId == id)
                       .FirstOrDefault();
            return View(ThisUser);
        }
    }
}
