
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages.Admin
{

    public class ManagerModel : PageModel
    {
        public IActionResult OnGet()
        {
            var current = HttpContext.Session.GetString("CurrentUser");
            User currentUser = null;
            if(current != null)
            {
                currentUser = JsonConvert.DeserializeObject<User>(current);
                if(currentUser.UserRoleId == 1)
                {
                    return Page();
                }
            }
            //return Redirect("/login");
            return Page();
        }
    }
}
