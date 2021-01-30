using Microsoft.AspNetCore.Mvc;

namespace AspNetCore0005.Controllers
{
    [Route("hoge")]
    public class HogeController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            return new ContentResult { Content = "Hoge" };
        }

        [Route("hogepage")]
        public IActionResult HogePage()
        {
            return new ContentResult { Content = $"HogePage !!!!!!!!!!!!!!" };
        }

        [Route("hogepage/{value}")]
        public IActionResult HogePage(string value)
        {
            return new ContentResult { Content = $"HogePage {value}"  };
        }

        [Route("/hg")]
        public IActionResult HogePage2()
        {
            return new ContentResult { Content = $"HogePage hg" };
        }
    }
}
