using System;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore0005.Controllers
{
    public class DateController : Controller
    {
        public IActionResult Day(int offset)
        {
            var day = DateTime
                .Now
                .Date
                .AddDays(offset)
                .ToString("yyyy/MM/dd(ddd)");
            //var t = String.Format("{0}", day);
            return new ContentResult { Content = $"{day}" };
        }
    }
}
