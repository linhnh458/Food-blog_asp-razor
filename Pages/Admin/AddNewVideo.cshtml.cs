using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages.Admin
{
    public class VideoCreated
    {
        public string Title { get; set; }
        public string Youtube { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }

    public class AddNewVideoModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        [BindProperty]
        public VideoCreated VideoCreated { get; set; }
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

        public IActionResult OnPost()
        {
            string title = VideoCreated.Title;
            string link = VideoCreated.Youtube;
            string embed = link.Split('=').Last();
            string desc = VideoCreated.Description;
            int status = int.Parse(Request.Form["videoStatus"]);
            Video vid = new()
            {
                Id = 0,
                Title = title,
                YoutubeLink = link,
                EmbeddedLink = embed,
                Description = desc,
                Status = true ? status == 1 : status == 0
            };
            context.Videos.Add(vid);
            context.SaveChanges();
            return Redirect("/admin/videoSettings");
        }
    }
}


