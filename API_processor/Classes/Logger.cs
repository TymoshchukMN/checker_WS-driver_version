using System.Text;

namespace API_processor.Classes
{
    public class Logger
    {
        private static readonly SemaphoreSlim _semaphore = new (1, 1);

        public static async void AddLogAsync(DateTime time, string error, string pc)
        {
            await _semaphore.WaitAsync();

            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Data");

            Directory.CreateDirectory(uploadDirectory);

            var filePath = Path.Combine(uploadDirectory, "logs.txt");

            StringBuilder stringBuilder = new ();

            stringBuilder.Append($"{time};{pc};{error}\n");

            try
            {
                await File.AppendAllTextAsync(filePath, stringBuilder.ToString());
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
