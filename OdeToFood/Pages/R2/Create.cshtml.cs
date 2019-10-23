using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OdeToFood.Pages.R2
{
    public class CreateModel : PageModel
    {
        private readonly OdeToFoodDbContext _context;
        private readonly IHtmlHelper _htmlHelper;
        [BindProperty]
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public CreateModel(OdeToFoodDbContext context, IHtmlHelper htmlHelper)
        {
            _context = context;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet()
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }



        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            _context.Restaurants.Add(Restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}