using CinemaProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.Pages
{
    [Authorize]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly SendEmailService _sendEmail;

        public PrivacyModel(ILogger<PrivacyModel> logger, SendEmailService sendEmailService)
        {
            _logger = logger;
            _sendEmail = sendEmailService;
        }
        public void OnGet()
        {
        }
        public ActionResult OnPost()
        {
            _sendEmail.SendEmailTicket("activatorkosz@o2.pl", "przykładowy film");
            return Page();
        }
    }
}
