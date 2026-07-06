using VersionStorage.Mappers;
using VersionStorage.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Viewer_WS_driver_version.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<WSwersionData> WSwersionDatas { get; set; } = [];
        public IEnumerable<string> UniqueVersions { get; set; } = [];

        public void OnGet()
        {
            var data = Processor.GetWSversions();
            WSwersionDatas = data;

            UniqueVersions = data.Select(x => x.FileVersion).Distinct().ToList();
        }
    }
}