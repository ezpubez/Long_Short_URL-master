using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Long_Short_URL.Models;
using Microsoft.EntityFrameworkCore;
using Long_Short_URL.Data;
using Microsoft.AspNetCore.Hosting;

namespace Long_Short_URL.Controllers
{
    public class CreateEditController : Controller
    {
        // Для взаимодействия с бд.
        private LinkContext db;
        public CreateEditController(LinkContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            // Получаем данные с бд, создаем список и передаем в представление.
            return View(await db.Links.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CutLink(string longUrl)
        {
            // Фабрика сокращённых ссылок.
            var manager = new ShortLink();
            // Новая ссылка.
            var link = manager.Cut(longUrl);
            // Проверка на соответствие ссылки формату.
            if (link == null)
            {
                ViewBag.Message = "Ошибка: Введённая строка не соответствует формату URL";
                return View("Index");
            }
            await db.Links.AddAsync(link);
            await db.SaveChangesAsync();

            return View(link);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Link link)
        {
            // Формируем sql-выражение Insert.
            db.Links.Add(link);
            // Добавляем в бд.
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // Обновление записи в бд.
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit(Link link)
        {
            // Sql-выражение Update.
            db.Links.Update(link);
            // Добавление в бд.
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
