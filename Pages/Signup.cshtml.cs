using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages
{
    public class Account
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
    public class SignupModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        [BindProperty]
        public Account RegisterAccount { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost() {
            string email = RegisterAccount.Email;
            string username = RegisterAccount.Username;
            string password = RegisterAccount.Password;
            string repass = RegisterAccount.RePassword;
            if (CheckEmailExistence(email) == false) {
                if (password.Equals(repass))
                {
                    User newUser = new()
                    {
                        Id = 0,
                        Email = email,
                        Username = username,
                        Password = password,
                        UserRoleId = 3
                    };
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    return Redirect("/login");
                }
            }
            ViewData["Error"] = "This email has been used";
            return Page();
        }

        bool CheckEmailExistence(string email)
        {
            List<User> users = context.Users.ToList();
            foreach(var u in users)
            {
                if(u.Email.ToLower().Equals(email.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
