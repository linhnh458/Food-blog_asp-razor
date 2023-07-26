using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project_Blog.Models;
using static System.Net.Mime.MediaTypeNames;

namespace PRN221_Project_Blog.Pages.Admin
{
    
    public class VideoSettingsModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        public List<Video> listVideo = new List<Video>();
        public void OnGet()
        {
            listVideo = context.Videos.ToList();
        }

        public IActionResult OnPost() {
            
            return Redirect("");
        }
    }
}
