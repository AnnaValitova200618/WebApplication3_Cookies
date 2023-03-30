using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using WebApplication3_Cookies.DB;
using WebApplication3_Cookies.Models;

namespace WebApplication3_Cookies.Pages
{
  
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public User User { get; set; } = new User();
        public string Message { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public async Task<ActionResult> OnPost()
        {
            if(string.IsNullOrEmpty(User.Login) || string.IsNullOrEmpty(User.Password))
            {
                Message = "Необходимо заполнить поля";
                return null;
            }
            var user = DBInstance.GetInstance().Users.FirstOrDefault(s=>s.Login == User.Login && s.Password == Hash.HashPass(User.Password));
            if(user == null)
            {
                Message = "Пользователь не найден";
                return null;
            }
            var claim = new List<Claim> { new Claim("id", user.Id.ToString()) };
            await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(new ClaimsIdentity(claim, "Cookies")));
            return RedirectToPage("Privacy");
        }
    }
}