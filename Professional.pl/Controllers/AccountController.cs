using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Profissonal.PPL.ModelVM;
using Profissonal.PPL.Service.Abstract;

namespace Professonal.pl.Controllers
{
    public class AccountController : Controller
    {
        public IAcountService AcountService { get; }

        public AccountController(IAcountService acountService)
        {
            AcountService = acountService;
        }

        // GET: Login
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Admin");
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await AcountService.LoginAsync(model);

            if (result.Secsses==true)
                return RedirectToAction("Index", "Admin");

            ModelState.AddModelError("", result.MessageError);
            return View(model);
        }

        // POST: LogOut
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await AcountService.LogOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // GET: Admins
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Admins()
        {
            var result = await AcountService.GetAllAdminAsync();
            return View(result);
        }

        // GET: AddAdmin
        [Authorize]
        [HttpGet]
        public IActionResult AddAdmin()
            => View();

        // POST: AddAdmin
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmin(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await AcountService.RegisterAdminAsync(model);

            if (result.Secsses==true)
            {
                TempData["Success"] = "تم إضافة الأدمن بنجاح ✅";
                return RedirectToAction("Admins");
            }

            ModelState.AddModelError("", result.MessageError);
            return View(model);
        }
        public async Task<IActionResult > DeleteAdmin(string id)
        {
            await AcountService.DeleteAdminAsync(id);
            TempData["Success"] = "تم حذف الأدمن بنجاح ✅";

            return RedirectToAction("Admins");
        }
    }
}