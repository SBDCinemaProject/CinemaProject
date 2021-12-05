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
    public class LoginEmployeeModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;
        [BindProperty]
        public string Surname { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public Worker Worker { get; set; }
        public LoginEmployeeModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }
        public ActionResult OnPost()
        {
            Worker = _context.Workers
                   .Where(x => x.Surname == Surname && x.Password == Password)
                   .FirstOrDefault();
            if (Worker == null)
            {
                return Page();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Worker.WorkerId.ToString()),
                new Claim(ClaimTypes.Name, Worker.Surname),
                new Claim(ClaimTypes.Role, "Worker"),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));

            return RedirectToPage("./Index");
        }
    }
}
