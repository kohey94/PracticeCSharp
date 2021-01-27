using Microsoft.AspNetCore.Mvc;

namespace AspNetCore0005.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public IActionResult Index()
        {
            return new ContentResult { Content = "Home.index" };
        }

        
    }
}
