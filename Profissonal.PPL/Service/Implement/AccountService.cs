using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Profissonal.PPL.Service.Implement
{
    public class AccountService : IAcountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager) // ← ضيفه هنا
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Response<string>> LoginAsync(LoginVM login)
        {
            // أول حاجة، ابحث عن الـ user
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
                return new Response<string>(null, false, "الإيميل أو الباسورد غلط");

            var result = await _signInManager.PasswordSignInAsync(
                login.Email,
                login.Password,
                login.rememberme,
                lockoutOnFailure: false
            );

            if (result.Succeeded)
            {
                // ضيف FullName كـ Claim
                var existingClaims = await _userManager.GetClaimsAsync(user);
                var fullNameClaim = existingClaims.FirstOrDefault(c => c.Type == "FullName");

                if (fullNameClaim == null)
                {
                    await _userManager.AddClaimAsync(user,
                        new System.Security.Claims.Claim("FullName", user.FullName ?? ""));
                }

                // Sign in تاني عشان يحمل الـ Claims الجديدة
                await _signInManager.RefreshSignInAsync(user);

                return new Response<string>("تم تسجيل الدخول", true, null);
            }

            return new Response<string>(null, false, "الإيميل أو الباسورد غلط");
        }

        public async Task LogOutAsync()
            => await _signInManager.SignOutAsync();

        public async Task<Response<string>> RegisterAdminAsync(RegisterVM model)
        {
            var existing = await _userManager.FindByEmailAsync(model.Email);
            if (existing != null)
                return new Response<string>(null, false, "الإيميل موجود بالفعل");

            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return new Response<string>("تم إضافة الأدمن", true, null);

            var error = result.Errors.FirstOrDefault()?.Description;
            return new Response<string>(null, false, error);
        }

        public async Task<Response<List<AdminVM>>> GetAllAdminAsync()
        {
            var admins = await _userManager.Users.ToListAsync();

            var result = admins.Select(a => new AdminVM
            {
                Id = a.Id,
                Name = a.FullName,
                Email = a.Email
            }).ToList();

            return new Response<List<AdminVM>>(result, true, null);
        }
        public async Task<Response<bool>> DeleteAdminAsync(string id)
        {
            try
            {
              var user=  await _userManager.FindByIdAsync(id);
                await _userManager.DeleteAsync(user);
                return new Response<bool>(true, false, null);

            }
            catch (Exception ex)
            {
                return new Response<bool>(false, false, null);


            }
        }
    }
}