using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CinemaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages
{
    public class EmployeeAccountIndexModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;
        public EmployeeAccountIndexModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }
        public Worker Worker { get; set; }
        public ActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                //get id of current user by checking his claim
                decimal workerId = decimal.Parse(User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                   .Select(c => c.Value).SingleOrDefault());

                Worker = _context.Workers
                   .Where(x => x.WorkerId == workerId)
                   .FirstOrDefault();

                foreach(var user in User.Claims)
                {

                }
                if (Worker == null)
                {
                    return RedirectToPage("/Index");
                }
            }
            return Page();
        }
    }
}
