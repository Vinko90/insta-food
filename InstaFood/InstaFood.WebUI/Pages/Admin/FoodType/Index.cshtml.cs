using InstaFood.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstaFood.WebUI
{
    [Authorize(Roles = StaticDetails.ManagerRole)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}