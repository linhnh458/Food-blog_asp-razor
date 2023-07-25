using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages
{
    public class LoginInfo
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();

        [BindProperty]
        public LoginInfo UserInfo { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string username = UserInfo.Username;
            string password = UserInfo.Password;
            User userinfo = CheckLogin(username, password); 
            if (userinfo != null)
            {
                HttpContext.Session.SetString("CurrentUser", JsonConvert.SerializeObject(userinfo));
                return Redirect("/home");
            }
            else
            {
                string message = "Account not found";
                ViewData["Message"] = message;
                return Page();
            }
        }

        User CheckLogin(string email, string password)
        {
            User userInfo = context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if(userInfo != null)
            {
                return userInfo;
            }
            return null;
        }
    }
}
