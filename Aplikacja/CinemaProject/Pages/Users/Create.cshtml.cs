using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaProject.Models;

namespace CinemaProject.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public CreateModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User ThisUser { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            bool isUsernameAlreadyTaken = _context.Users.Any(x => x.Username == ThisUser.Username);

            if(isUsernameAlreadyTaken)
            {
                ModelState.AddModelError("username", "Username is already taken");
            }
                                          
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Find last id
            if (_context.Users.Count() != 0)
            {
                decimal id = _context.Users
                .Select(x => x.UserId)
                .Max();
                ThisUser.UserId = id + 1;
            }

            _context.Users.Add(ThisUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
