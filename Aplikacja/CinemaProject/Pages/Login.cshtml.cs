using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CinemaProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages
{
    public class LoginModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public User User { get; set; }
        public LoginModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            
        }
        public ActionResult OnPost()
        {
            User = _context.Users
                   .Where(x => x.Username == Username && x.Password == Password)
                   .FirstOrDefault();
            if (User == null)
            {
                return Page();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, User.UserId.ToString()),
                new Claim(ClaimTypes.Name, User.Username),
                new Claim(ClaimTypes.Role, "User"),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));

            return RedirectToPage("./Index");
        }
    }
}
