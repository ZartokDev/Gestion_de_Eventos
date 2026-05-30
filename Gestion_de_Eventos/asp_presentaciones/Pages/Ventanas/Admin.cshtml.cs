using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentaciones.Pages
{
    [Authorize]
    public class AdminModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
