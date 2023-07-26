using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages.Admin
{
    public class AddVideoModel : PageModel
    {
        public class VideoCreated
        {
            public string Title { get; set; }
            public string YoutubeLink { get; set; }
            public string Description { get; set; }
            public int Status { get; set; }

        }
        public class VideoSettingsModel : PageModel
        {
            PRN221_Project_FoodBlogContext context = new();
            [BindProperty]
            public VideoCreated VideoCreated { get; set; }
            public void OnGet()
            {

            }

            public IActionResult OnPost()
            {
                //string title = VideoCreated.Title;
                //string link = VideoCreated.YoutubeLink;
                //string embed = link.Split('=').Last();
                //string desc = VideoCreated.Description;
                //int status = VideoCreated.Status;
                //Video vid = new()
                //{
                //    Id = 0,
                //    Title = title,
                //    YoutubeLink = link,
                //    EmbeddedLink = embed,
                //    Description = desc,
                //    Status = true ? status == 1 : status == 0
                //};
                //context.Videos.Add(vid);
                //context.SaveChanges();
                return Redirect("/admin/videoSettings");
            }
        }
    }
}
