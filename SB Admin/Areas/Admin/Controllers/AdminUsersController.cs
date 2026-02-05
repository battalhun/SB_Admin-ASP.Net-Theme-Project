using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace SB_Admin.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LİSTE
        public async Task<IActionResult> Index()
        {
            var users = await _context.AdminUsers.AsNoTracking().ToListAsync();
            return View(users);
        }

        // CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminUser model, string password)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError(nameof(password), "Parola girilmesi zorunludur.");
                return View(model);
            }

            // Örnek: kullanıcı adı benzersizliği kontrolü
            if (await _context.AdminUsers.AnyAsync(u => u.UserName == model.UserName))
            {
                ModelState.AddModelError(nameof(model.UserName), "Bu kullanıcı adı zaten kullanılıyor.");
                return View(model);
            }

            model.PasswordHash = PasswordHelper.HashPassword(password);
            model.IsActive = true;

            await _context.AdminUsers.AddAsync(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // EDIT GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var user = await _context.AdminUsers.FindAsync(id.Value);

            if (user == null)
                return NotFound();

            return View(user);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdminUser model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _context.AdminUsers.FindAsync(model.Id);

            if (user == null)
                return NotFound();

            // Güncellenmesine izin verilen alanlar
            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.Phone = model.Phone;
            user.IsActive = model.IsActive;

            // Parola güncellemesi yapılacaksa ayrı bir yol/işlem oluşturun.
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // DELETE GET - onay sayfası (Index'teki linkler GET ile Delete action'ına gidiyorsa çalışır)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var user = await _context.AdminUsers.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id.Value);

            if (user == null)
                return NotFound();

            return View(user);
        }

        // DELETE POST - gerçek silme işlemi
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.AdminUsers.FindAsync(id);

            if (user == null)
                return NotFound();

            _context.AdminUsers.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
