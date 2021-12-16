using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace CinemaProject.Pages.Users
{
    [Authorize(Roles = "Worker")]
    public class IndexModel : PageModel
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public IndexModel(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }

        public IList<User> UserList { get;set; }

        public async Task OnGetAsync()
        {
            UserList = await _context.Users.ToListAsync();
        }
    }
}
