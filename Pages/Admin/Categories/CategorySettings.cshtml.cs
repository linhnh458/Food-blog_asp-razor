using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
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

        public IActionResult OnGetDeleteCategory(int cateid)
        {
            Category c = context.Categories.FirstOrDefault(x => x.Id == cateid);
            if (c != null)
            {
                try
                {
                    context.Categories.Remove(c);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = "Cannot delete this category, you need to delete all blogs with this category first.";
                    return Page();
                    //return RedirectToPage("/admin/categories/categorySettings");
                }
               
            }
            return RedirectToPage("/admin/categories/categorySettings");
        }

    }
}
