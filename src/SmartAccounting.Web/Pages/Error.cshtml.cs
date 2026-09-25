using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartAccounting.Web.Models;

namespace SmartAccounting.Web.Pages
{
    public class ErrorModel : PageModel
    {
        public ErrorViewModel Error { get; private set; }

        public void OnGet()
        {
            Error = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
        }
    }
}
