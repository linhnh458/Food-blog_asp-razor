using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages.Admin.Videos
{
    public class VideoSettingsModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        public List<Video> listVideo = new List<Video>();
        public void OnGet()
        {
            listVideo = context.Videos.ToList();
        }

        public IActionResult OnGetChangeStatus(int id)
        {
            Video c = context.Videos.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                if (c.Status == true)
                {
                    c.Status = false;
                }
                else
                {
                    c.Status = true;
                }
            }
            context.SaveChanges();
            return RedirectToPage("/admin/videos/videoSettings");
        }
    }
}
