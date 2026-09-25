using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmartAccounting.Web.Pages
{
    [Authorize(Policy = "Dashboard.View")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}