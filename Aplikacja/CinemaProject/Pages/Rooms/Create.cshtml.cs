using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaProject.Models;

namespace CinemaProject.Pages.Rooms
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
        ViewData["CinemaCinemaId"] = new SelectList(_context.Cinemas, "CinemaId", "City");
            return Page();
        }

        [BindProperty]
        public Room Room { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //Find last id
            if (_context.Rooms.Count() != 0)
            {
                decimal id = _context.Rooms
                .Select(x => x.RoomId)
                .Max();
                Room.RoomId = id + 1;
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Room.IsAvalible == "true")
                Room.IsAvalible = "1";
            else if (Room.IsAvalible == "false")
                Room.IsAvalible = "0";

            _context.Rooms.Add(Room);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
