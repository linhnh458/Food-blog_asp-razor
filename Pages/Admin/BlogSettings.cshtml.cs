using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages.Admin
{
    public class BlogSettingsModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        public List<Blog> listBlog = new List<Blog>();
        public List<Category> listCate = new List<Category>();
        public void OnGet()
        {
            listBlog = context.Blogs.Include(x => x.Author).ToList();
            listCate = context.Categories.ToList();
        }

        public IActionResult OnGetDeleteBlog(int blogid)
        {
            Blog blog = context.Blogs.FirstOrDefault(x => x.Id == blogid);
            if(blog == null)
            {
                return NotFound();
            }
            //context.Blogs.Remove(blog);
            //context.SaveChanges();
            ViewData["Message"] = "Deleted successfully";
            return Page();
        }
    }
}
