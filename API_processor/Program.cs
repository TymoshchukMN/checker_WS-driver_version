using System.Text;
using API_processor.Mappers;

namespace API_processor
{
    public class Program
    {
        private static readonly SemaphoreSlim _semaphore = new (1, 1);

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapPost("/add", async (WSwersionData rawData) =>
            {
                Console.WriteLine(rawData);

                var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Data");

                Directory.CreateDirectory(uploadDirectory);

                var filePath = Path.Combine(uploadDirectory, "DataFromPCs.txt");

                StringBuilder tempString = new ();
                tempString.Append($"{rawData.ComputerName};");
                tempString.Append($"{rawData.CkeckDate};");
                tempString.Append($"{rawData.²sFileWxists};");
                tempString.AppendLine($"{rawData.FileVersion};");

                await _semaphore.WaitAsync();

                try
                {
                    await File.AppendAllTextAsync(filePath, tempString.ToString());
                }
                finally
                {
                    _semaphore.Release();
                }

                Console.WriteLine("done");
            });

            app.Run();
        }
    }
}