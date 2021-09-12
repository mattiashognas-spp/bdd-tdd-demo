using System;
using System.Collections.Generic;
using System.Linq;
using lab.api.Contracts;
using lab.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab.api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Redirect("/swagger/index.html");
        }
    }
}
