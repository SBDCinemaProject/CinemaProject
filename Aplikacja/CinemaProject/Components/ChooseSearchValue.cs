using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.Components
{
    public class ChooseSearchValue : ViewComponent
    {
        private readonly CinemaProject.Models.ModelContext _context;

        public ChooseSearchValue(CinemaProject.Models.ModelContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string selectedValue { get; set; }

    }
}
