using CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using CoreLayer.DTOs.Users;
using CoreLayer.Utilities;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Blog.Pages.Auth
{
    [ValidateAntiForgeryToken]
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        #region Properties
        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        public string Username { get; set; }

        [Required(ErrorMessage = "کلمه عبور را وارد کنید")]
        [MinLength(6, ErrorMessage = "کلمه عبور معتبر نیست")]
        public string Password { get; set; }

        #endregion
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = _userService.LoginUser(new LoginUserDto()
            {
                UserName = Username,
                Password = Password,
            });

            if(user == null)
            {
                ModelState.AddModelError("Username", "User not found!");
                return Page();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim("Test", "Test"),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Fullname.ToString()),
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = true,
            };
            HttpContext.SignInAsync(claimPrincipal, properties);

            return RedirectToPage("../Index"); // return Redirect("/Index");
        }
    }
}
