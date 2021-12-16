using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Tickets
{
    public class BoughtTicketModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            return RedirectToPage("../Index");
        }
    }
}
