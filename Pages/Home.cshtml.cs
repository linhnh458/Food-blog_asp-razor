using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages
{
    public class HomeModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        public List<Blog> listBlog = new List<Blog>();
        public List<Category> listCate = new List<Category>();
        public void OnGet()
        {
            listBlog = context.Blogs.Include(x => x.Author).ToList();
            listCate = context.Categories.ToList();
        }
    }
}
