using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CinemaProject.Pages.Tickets
{
    public class BuyTicketModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public BuyTicketModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Screening Screening { get; set; }
        [BindProperty]
        public Ticket Ticket { get; set; }
        [BindProperty]
        public User ThisUser { get; set; }
        public IActionResult OnGet()
        {
            ViewData["ScreeningScreeningId"] = new SelectList(_context.Screenings, "ScreeningId", "ScreeningId");
            ViewData["UserUserId"] = new SelectList(_context.Users, "UserId", "Email");
            var SessionScreening =
            HttpContext.Session.GetString("Screening");

          
                Screening =
                JsonConvert.DeserializeObject<Screening>(SessionScreening);
            var SessionUser =
            HttpContext.Session.GetString("User");


            ThisUser =
            JsonConvert.DeserializeObject<User>(SessionUser);
            return Page();
               
        }
        public async Task<IActionResult> OnPost()
        {
            /*if (!ModelState.IsValid)
            {
                return RedirectToPage("Edit");
            }*/

            _context.Tickets.Add(Ticket);
            await _context.SaveChangesAsync();

           return RedirectToPage("./Index");
        }
    }
}
