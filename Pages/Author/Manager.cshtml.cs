using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages.Author
{
    public class ManagerModel : PageModel
    {
        // only allow authors to crud posts
        public IActionResult OnGet()
        {
            var current = HttpContext.Session.GetString("CurrentUser");
            User currentUser = null;
            if (current != null)
            {
                currentUser = JsonConvert.DeserializeObject<User>(current);
                if (currentUser.UserRoleId == 2)
                {
                    return Page();
                }
            }
            return Redirect("/login");
        }
    }
}
