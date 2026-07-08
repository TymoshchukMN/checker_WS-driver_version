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
    }
}