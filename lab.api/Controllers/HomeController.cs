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
