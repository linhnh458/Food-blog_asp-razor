using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages.Admin.Categories
{
    public class AddCategoryModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        [BindProperty]
        public string CateName { get; set; }
        public IActionResult OnGet()
        {
            var current = HttpContext.Session.GetString("CurrentUser");
            User currentUser = null;
            if (current != null)
            {
                currentUser = JsonConvert.DeserializeObject<User>(current);
                if (currentUser.UserRoleId == 1)
                {
                    return Page();
                }
            }
            return Redirect("/login");
        }

        public IActionResult OnPost() {
            string catename = CateName;
            if(!string.IsNullOrEmpty(catename))
            {
                if(CheckCateExistence(catename) == false)
                {
                    Category category = new Category()
                    {
                        Id = 0,
                        Category1 = catename
                    };
                    context.Categories.Add(category);
                    context.SaveChanges();
                    return Redirect("/admin/categories/categorySettings");
                }
                else
                {
                    ViewData["ErrorMessage"] = "This category has already existed";
                    return Page();
                }
            }

            return Page();
        }

        bool CheckCateExistence(string catename)
        {
            List<Category> listCate = context.Categories.ToList();
            foreach(var c in listCate)
            {
                if(c.Category1.ToLower().Equals(catename.ToLower())) { 
                    return true;
                }
            }
            return false;
        }
    }
}
