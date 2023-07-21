using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages.Videos
{
    public class IndexModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        public List<Video> listVideo = new List<Video>();
        public List<Category> listCate = new List<Category>();
        public void OnGet()
        {
            listCate = context.Categories.ToList();
            listVideo = context.Videos.ToList();
        }
    }
}
