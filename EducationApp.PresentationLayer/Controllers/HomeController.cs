using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //public async Task<IActionResult> SendMessage()
        //{
        //    EmailSender emailService = new EmailSender();
        //    await emailService.SendingEmailAsync("educationappgoncharuk2019@gmail.com", "Тема письма", "Тест письма: тест!");
        //    return RedirectToAction("Index");
        //}
    }
}