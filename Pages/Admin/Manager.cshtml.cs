
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PRN221_Project_Blog.Models;
using System.Data;

namespace PRN221_Project_Blog.Pages.Admin
{
    public class BlogCreated
    {
        public string Title { get; set; }
        public int Category { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }

    public class ManagerModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        public List<Category> listCate = new List<Category>();
        [BindProperty]
        public BlogCreated BlogCreated { get; set; }

        public IActionResult OnGet()
        {
            var current = HttpContext.Session.GetString("CurrentUser");
            User currentUser = null;
            if (current != null)
            {
                currentUser = JsonConvert.DeserializeObject<User>(current);
                if (currentUser.UserRoleId == 1)
                {
                    listCate = context.Categories.ToList();
                    return Page();
                }
            }
            return Redirect("/login");
        }

        public IActionResult OnPost()
        {
            string title = BlogCreated.Title;
            string content = BlogCreated.Content;
            int cateid = int.Parse(Request.Form["cates"]);
            int status = int.Parse(Request.Form["status"]);
            DateTime created = BlogCreated.CreatedDate;
            string description = BlogCreated.Description;
            string img = "";
            var file = Request.Form.Files["blogimg"];
            if (file != null && file.Length > 0)
            {
                img = file.FileName;
            }
            var current = HttpContext.Session.GetString("CurrentUser");
            User currentUser = null;
            if (current != null)
            {
                currentUser = JsonConvert.DeserializeObject<User>(current);
            }

            Blog blog = new()
            {
                Id = 0,
                Title = title,
                Content = content,
                Image = img,
                CategoryId = cateid,
                CreatedDate = created,
                Description = description,
                Status = status,
                AuthorId = currentUser.Id
            };
            context.Blogs.Add(blog);
            context.SaveChanges();
            return Redirect("/admin/blogSettings");
        }
    }
}
