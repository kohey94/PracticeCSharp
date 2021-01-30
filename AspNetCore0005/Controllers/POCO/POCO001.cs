using System;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore0005.Controllers.POCO
{
    // Controllerを継承しないコントローラーはPOCOコントローラーと呼ばれる。
    // Controller共通の処理が利用できなくなったり、実装が冗長になったりするが、オーバーヘッドやメモリ消費の削減になる。
    [Controller]
    [Route("poco1")]
    public class POCO001
    {
        public IActionResult Index()
        {
            return new ContentResult()
            {
                Content = DateTime.Now.ToString("ddd, d MMM")
            };
        }

        [Route("html")]
        public IActionResult Html()
        {
            return new ContentResult()
            {
                Content = "<h1>Hello Html</h1>",
                ContentType = "text/html",
                StatusCode = 200

            };
        }
    }
}
