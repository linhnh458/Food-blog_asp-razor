using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages.Admin.Comments
{
    public class ManagerModel : PageModel
    {
        PRN221_Project_FoodBlogContext context;
        public List<Comment> listComment = new List<Comment>();
        public void OnGet()
        {
            listComment = context.Comments.ToList();
        }
    }
}
