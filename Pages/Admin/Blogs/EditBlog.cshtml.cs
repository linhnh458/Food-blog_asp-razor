using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages.Admin.Blogs
{
    public class BlogEdit
    {
        public string Title { get; set; }
        public int Category { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
    public class EditBlogModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        public List<Category> listCate = new List<Category>();
        public Blog blog = null;
        [BindProperty]
        public BlogEdit BlogEdit { get; set; }
        public void OnGet(int blogid)
        {
            listCate = context.Categories.ToList();
            blog = context.Blogs.FirstOrDefault(b => b.Id == blogid);
        }

        public IActionResult OnPost(int blogid)
        {
            blog = context.Blogs.FirstOrDefault(b => b.Id == blogid);
            blog.Title = BlogEdit.Title;
            blog.Content = BlogEdit.Content;
            blog.CreatedDate = BlogEdit.CreatedDate;
            blog.Description = BlogEdit.Description;
            blog.Status = BlogEdit.Status;
            blog.CategoryId = int.Parse(Request.Form["cates"]);
            string img = "";
            var file = Request.Form.Files["blogimg"];
            if (file != null && file.Length > 0)
            {
                img = file.FileName;
            }
            blog.Image = img;
            context.SaveChanges();
            return Redirect("/admin/blogs/blogSettings");
        }
    }
}
