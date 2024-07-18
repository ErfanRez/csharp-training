using CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using CoreLayer.DTOs.Users;
using CoreLayer.Utilities;

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

            var result = _userService.LoginUser(new LoginUserDto()
            {
                UserName = Username,
                Password = Password,
            });

            if(result.Status == OperationResultStatus.NotFound)
            {
                ModelState.AddModelError("Username", "User not found!");
            }

            return RedirectToPage("../Index"); // return Redirect("/Index");
        }
    }
}
