using Microsoft.AspNetCore.Mvc;

namespace AspNetCore0005.Controllers
{
    public class ActionController : Controller
    {
        // 暗黙的なアクション名: Index
        public IActionResult Index()
        {
            return new ContentResult { Content = "ActionController" };
        }

        public IActionResult Action1()
        {
            return new ContentResult { Content = "Action 1" };
        }

        [NonAction]
        public IActionResult Action2()
        {
            return new ContentResult { Content = "このアクションはブラウザから呼び出せない" };
        }

        [ActionName("Action-3")]
        public IActionResult Action3()
        {
            return new ContentResult { Content = "Action 3" };
        }
    }
}
