using VersionStorage.Classes;
using VersionStorage.Mappers;

namespace API_processor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapPut("/add", static async (WSwersionData rawData) =>
            {
                try
                {
                    Processor.AddData(rawData);
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