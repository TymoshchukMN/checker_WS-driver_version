using Microsoft.AspNetCore.Mvc;
using VersionStorage.Mappers;

namespace Viewer_WS_driver_version.Pages
{
    public class InventoryModel : BasePageModel
    {
        public IEnumerable<WScountByPC> WScountByPC { get; set; } = [];

        public void OnGet()
        {
            using var client = new HttpClient();

            try
            {
                var data = client.GetFromJsonAsync<List<WScountByPC>>($"{Url}GetWSCountByPC").Result;

                if (data != null)
                {
                    WScountByPC = data; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IActionResult OnGetPCByFileVersion(string version)
        {
            using var client = new HttpClient();
            
            try
            {
                var data = client.GetFromJsonAsync<List<WSwersionData>>($"{Url}getPCbyVersions/{version}").Result;
                if (data != null)
                {
                    return new JsonResult(data);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }

            return new JsonResult(false);
        }
    }
}