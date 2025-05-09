using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers
{
    public class AutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
