using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CinemaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaProject.Pages
{
    public class UserAccountIndexModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;
        public UserAccountIndexModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }
        public User ThisUser { get; set; }
        public ActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                //get id of current user by checking his claim
                decimal userId = decimal.Parse(User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                   .Select(c => c.Value).SingleOrDefault());

                ThisUser = _context.Users
                   .Include(x => x.Tickets).ThenInclude(y => y.ScreeningScreening).ThenInclude(z => z.MovieMovie)
                   .Where(x => x.UserId == userId)
                   .FirstOrDefault();
                if (User == null)
                {
                    return RedirectToPage("/Index");
                }
            }
            return Page();
        }
    }
}
