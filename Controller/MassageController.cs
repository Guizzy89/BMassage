using BMassage.Data;
using BMassage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BMassage.Controllers
{
    public class MassageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MassageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Massage
        public IActionResult Index()
        {
            return View(_context.Massages.ToList());
        }

        // GET: Massage/Details/{id}
        public IActionResult Details(int id)
        {
            var massage = _context.Massages.Find(id);
            if (massage == null)
                return NotFound();

            return View(massage);
        }

        // GET: Massage/Create
        public IActionResult Create() => View();

        // POST: Massage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price")] Massage massage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(massage);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Услуга успешно добавлена!";
                return RedirectToAction(nameof(Index));
            }
            return View(massage);
        }

        // GET: Massage/Edit/{id}
        public IActionResult Edit(int id)
        {
            var massage = _context.Massages.Find(id);
            if (massage == null)
                return NotFound();
            return View(massage);
        }

        // POST: Massage/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price")] Massage massage)
        {
            if (id != massage.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(massage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw new Exception($"Ошибка обновления услуги №{id}. Возможно, она уже была изменена.");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(massage);
        }

        // GET: Massage/Delete/{id}
        public IActionResult Delete(int id)
        {
            var massage = _context.Massages.Find(id);
            if (massage == null)
                return NotFound();
            return View(massage);
        }

        // POST: Massage/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var massage = _context.Massages.Find(id);
            if (massage != null)
            {
                _context.Massages.Remove(massage);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}