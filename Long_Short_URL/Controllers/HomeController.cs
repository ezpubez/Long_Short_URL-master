using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Long_Short_URL.Models;
using Microsoft.EntityFrameworkCore;

namespace Long_Short_URL.Controllers
{
    public class HomeController : Controller
    {
        // Для взаимодействия с бд.
        private LinkContext db;
        public HomeController(LinkContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            // Получаем данные с бд, создаем список и передаем в представление.
            return View(await db.Links.ToListAsync());
        }

        [HttpGet]
        [ActionName("Delete")]
        // Извлекаем объект из бд и передаем в представление.
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Link link = await db.Links.FirstOrDefaultAsync(p => p.Id == id);
                if (link != null)
                    return View(link);
            }
            return NotFound();
        }

        [HttpPost]
        // Получаем и удаляем объект.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Link link = await db.Links.FirstOrDefaultAsync(p => p.Id == id);
                if (link != null)
                {
                    // Sql-выражение Delete.
                    db.Links.Remove(link);
                    // Сохранение изменений в бд.
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}
