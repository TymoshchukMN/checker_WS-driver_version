using API_processor.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Viewer_WS_driver_version.Classes;

namespace Viewer_WS_driver_version.Pages
{
    public class IndexModel : PageModel
    {
        private readonly VersionsContext _db;

        public IndexModel(VersionsContext db)
        {
            _db = db;
        }

        public IEnumerable<WSwersionData> WSwersionDatas { get; set; } = [];

        public async void OnGetAsync()
        {
            WSwersionDatas = _db.WSwersionDatas;
        }
    }
}

