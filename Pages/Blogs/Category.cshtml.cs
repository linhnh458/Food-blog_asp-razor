using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages.Blogs
{
    public class CategoryModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        public List<Blog> listBlogByCate = new List<Blog>();
        public List<Category> listCate = new List<Category>();
        public Category category;
        public void OnGet(int cateid)
        {
            listBlogByCate = context.Blogs.Where(x => x.CategoryId == cateid).Include(x => x.Author).ToList();
            listCate = context.Categories.ToList();
            category = context.Categories.FirstOrDefault(x => x.Id == cateid);
        }
    }
}
