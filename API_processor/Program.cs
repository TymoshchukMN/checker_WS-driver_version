using System.Text;
using API_processor.Classes;
using API_processor.Mappers;
using Microsoft.EntityFrameworkCore;

namespace API_processor
{
    public class Program
    {
        private static readonly SemaphoreSlim _semaphore = new (1, 1);

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();

            builder.Services.AddDbContext<VersionsContext>(options =>
                options.UseSqlite("Data Source=C:\\microservices\\WS_driwer_reporter\\WSVersions.db"));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<VersionsContext>();
                db.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapPut("/add", async (WSwersionData rawData, VersionsContext db) =>
            {
                try
                {
                    var pc = await db.WSwersionDatas.FindAsync(rawData.ComputerName);

                    if (pc is null)
                    {
                        db.WSwersionDatas.Add(rawData);
                    }
                    else
                    {
                        pc.CheckDate = rawData.CheckDate;
                        pc.FileVersion = rawData.FileVersion;
                        pc.IsFileExists = rawData.IsFileExists;
                    }

                    await db.SaveChangesAsync();

                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    return Results.Problem(ex.Message);
                }
            });

            app.Run();
        }
    }
}