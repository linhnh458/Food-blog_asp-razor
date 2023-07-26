using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages
{
    public class TestiHome
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string Comment { get; set; }
    }
    public class HomeModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        public List<Blog> listBlog = new List<Blog>();
        public List<Category> listCate = new List<Category>();
        public List<Testimonial> testimonials = new List<Testimonial>();

        [BindProperty]
        public TestiHome Testimonial { get; set; }
        public void OnGet()
        {
            listBlog = context.Blogs.Include(x => x.Author).ToList();
            listCate = context.Categories.ToList();
            testimonials = context.Testimonials.ToList();
        }

        public IActionResult OnPost()
        { 
            string name = Testimonial.Name;
            string job = Testimonial.Job;
            string content = Testimonial.Comment;

            Testimonial t = new()
            {
                Id = 0,
                Name = name,
                Job = job,
                Content = content
            };
            context.Testimonials.Add(t);
            context.SaveChanges();
            return Redirect("/home");
        }
    }
}
