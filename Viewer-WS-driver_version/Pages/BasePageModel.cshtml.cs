using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Viewer_WS_driver_version.Pages
{
    public class BasePageModel : PageModel
    {
        protected readonly string Url = "http://172.16.0.54:7000/";
    }
}
