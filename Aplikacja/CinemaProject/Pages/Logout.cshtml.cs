using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;
        public LogoutModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }
        public ActionResult OnGet()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("./Index");
        }
    }
}
