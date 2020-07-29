using Long_Short_URL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Long_Short_URL.Controllers
{
    public class RedirectController : Controller
    {
        private readonly LinkContext db;
        // Внедрение зависимостей.
        public RedirectController(LinkContext context)
        {
            db = context;
        }
        // Перенаправить.
        public async Task<IActionResult> Rdrc(string id)
        {
            var lnk = await db.Links.Where(l => l.ShortUrl == id).FirstOrDefaultAsync();
            if (lnk != null)
            {
                return Redirect(lnk.LongUrl);
            }
            else
            {
                return Content("404");
            }
        }
    }
}
