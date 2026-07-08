using VersionStorage.Mappers;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Viewer_WS_driver_version.Pages
{
    public class IndexModel : BasePageModel
    {
        public IEnumerable<WSwersionData> WSwersionDatas { get; set; } = [];
        public IEnumerable<string> UniqueVersions { get; set; } = [];

        public void OnGet()
        {
            using HttpClient client = new ();

            try
            {
                var data = client.GetFromJsonAsync<List<WSwersionData>>(Url).Result;

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