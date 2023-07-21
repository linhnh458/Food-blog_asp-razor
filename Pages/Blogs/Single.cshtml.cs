using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages.Blogs
{
    public class CommentOnPost
    {
        public string CommentContent { get; set; }
    }
    public class SingleModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        public Blog SinglePost = null;
        public List<Category> listCate = new List<Category>();

        [BindProperty]
        public CommentOnPost CommentPost { get; set; }
        public void OnGet(int blogid)
        {
            listCate = context.Categories.ToList();
            SinglePost = context.Blogs.FirstOrDefault(x => x.Id == blogid);
        }

        public void OnPost()
        {
            int blogid = int.Parse(Request.HttpContext.Request.Query["blogid"]);
            string commentContent = CommentPost.CommentContent;
        }
    }
}
