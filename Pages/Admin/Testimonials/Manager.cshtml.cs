using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project_Blog.Models;

namespace PRN221_Project_Blog.Pages.Admin.Testimonials
{
    public class ManagerModel : PageModel
    {
        PRN221_Project_FoodBlogContext context = new();
        public List<Testimonial> listTesti = new List<Testimonial>();
        public void OnGet()
        {
            listTesti = context.Testimonials.ToList();
        }

        public IActionResult OnGetChangeStatus(int id)
        {
            Testimonial c = context.Testimonials.FirstOrDefault(x => x.Id == id);
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
            return RedirectToPage("/admin/testimonials/manager");
        }
    }
}
