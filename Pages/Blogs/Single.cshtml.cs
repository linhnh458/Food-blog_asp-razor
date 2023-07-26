using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PRN221_Project_Blog.Models;
using System.Reflection.Metadata;

namespace PRN221_Project_Blog.Pages.Blogs
{
    public class SingleModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        [BindProperty]
        public Blog SinglePost { get; set; }
        public List<Category> listCate = new List<Category>();
        public List<Comment> listComment = new List<Comment>();
        public List<Blog> listBlogSide = new List<Blog>();

        [BindProperty]
        public string PostComment { get; set; }
        
        public void OnGet(int blogid)
        {
            listCate = context.Categories.ToList();
            listComment = context.Comments.Where(x => x.Status == 1 && x.BlogId == blogid ).Include(x => x.UserNavigation).ToList();
            var AllBlogs = from blog in context.Blogs
                           orderby blog.CreatedDate descending
                           select blog;
            foreach (Blog blog in AllBlogs)
            {
                listBlogSide.Add(blog);
            }
            SinglePost = context.Blogs.FirstOrDefault(x => x.Id == blogid);
        }

        public IActionResult OnPost()
        {
            string currentU = HttpContext.Session.GetString("CurrentUser");
            string message = null;
            User currentUser = null;
            int blogid = int.Parse(Request.HttpContext.Request.Query["blogid"]);

            if (currentU == null)
            {
                message = "You must login to comment";
                ViewData["Error"] = message;
                return Page();
            }
            else
            {
                currentUser = JsonConvert.DeserializeObject<User>(currentU);
                string commentContent = PostComment;
                if (!string.IsNullOrEmpty(commentContent))
                {
                    Comment c = new()
                    {
                        Id = 0,
                        BlogId = blogid,
                        BlogTitle = SinglePost.Title,
                        Content = commentContent,
                        User = currentUser.Id,
                        Status = 0
                    };
                    context.Comments.Add(c);
                    context.SaveChanges();
                }
                else
                {
                    message = "Comment is empty";
                    ViewData["Error"] = message;
                    return Page();
                }
            }
            return Redirect("/blogs/single?blogid=" + blogid);
        }
    }
}
