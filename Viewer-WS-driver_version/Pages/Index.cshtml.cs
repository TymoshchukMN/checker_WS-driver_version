using VersionStorage.Mappers;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Viewer_WS_driver_version.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<WSwersionData> WSwersionDatas { get; set; } = [];
        public IEnumerable<string> UniqueVersions { get; set; } = [];

        public async Task OnGet()
        {
            const string Url = "http://172.16.0.54:7000/get";

            using HttpClient client = new ();

            try
            {
                var data = await client.GetFromJsonAsync<List<WSwersionData>>(Url);

                if (data!=null)
                {
                    WSwersionDatas = data;
                    UniqueVersions = data.Select(s => s.FileVersion).Distinct();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}