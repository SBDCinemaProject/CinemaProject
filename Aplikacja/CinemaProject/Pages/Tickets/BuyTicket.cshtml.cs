using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaProject.Models;
using CinemaProject.Services;
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
        private readonly SendEmailService _sendEmailService;

        public BuyTicketModel(CinemaProject.Models.ModelContext context, SendEmailService sendEmailService)
        {
            _context = context;
            _sendEmailService = sendEmailService;
        }

        [BindProperty]
        public Screening Screening { get; set; }
        [BindProperty]
        public Ticket Ticket { get; set; }
        [BindProperty]
        public Ticket TicketPom { get; set; }
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
            Ticket ticket1 = _context.Tickets
                .Find(Ticket.UserUserId, Ticket.ScreeningScreeningId);
            if (ticket1!=null)
            {
                return RedirectToPage("./BoughtTicket");
            }

            _context.Tickets.Add(Ticket);
            await _context.SaveChangesAsync();
            User user = _context.Users
                        .Where(x => x.UserId == Ticket.UserUserId).FirstOrDefault();
            Screening screening = _context.Screenings
                        .Where(x => x.ScreeningId == Ticket.ScreeningScreeningId)
                        .Include(x => x.MovieMovie).FirstOrDefault();
            _sendEmailService.SendEmailTicket(user.Email, screening.MovieMovie.Name);

           return RedirectToPage("../UserAccountIndex");
        }
    }
}
