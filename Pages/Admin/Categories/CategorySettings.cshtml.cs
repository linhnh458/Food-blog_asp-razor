using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages.Admin.Categories
{
    public class CategorySettingsModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        public List<Category> listCate = new List<Category>();
        public IActionResult OnGet()
        {
            var current = HttpContext.Session.GetString("CurrentUser");
            User currentUser = null;
            if (current != null)
            {
                currentUser = JsonConvert.DeserializeObject<User>(current);
                if (currentUser.UserRoleId == 1)
                {
                    listCate = context.Categories.ToList();
                    return Page();
                }
            }
            return Redirect("/login");
        }


    }
}
