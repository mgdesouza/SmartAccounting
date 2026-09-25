using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmartAccounting.Web.Pages.Admin;

[Authorize(Policy = "Admin.Manage")]
public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}
