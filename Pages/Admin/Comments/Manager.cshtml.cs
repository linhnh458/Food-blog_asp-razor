using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages.Admin.Comments
{
    public class ManagerModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        public List<Comment> listComment = new List<Comment>();
        public void OnGet()
        {
            listComment = context.Comments.Include(x => x.Blog).ToList();
        }

        public IActionResult OnGetChangeStatus(int id)
        {
            Comment c = context.Comments.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                if(c.Status == 1)
                {
                    c.Status = 0;
                }
                else
                {
                    c.Status = 1;
                }
            }
            context.SaveChanges();
            return RedirectToPage("/admin/comments/manager");
        }
    }
}
