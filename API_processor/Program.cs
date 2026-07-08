using VersionStorage.Classes;
using VersionStorage.Mappers;

namespace API_processor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            await Processor.DBCkeck();

            app.MapPut("/add", static async (WSwersionData rawData) =>
            {
                try
                {
                    await Processor.AddData(rawData);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    return Results.Problem(ex.Message);
                }
            });

            app.MapGet("/get", () =>
            {
                try
                {
                    var data = Processor.GetWSversions();

                    return Results.Ok(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    return Results.Problem(ex.Message);
                }
            });

            app.MapGet("/getPCbyVersions/{version}", async (string version) =>
            {
                try
                {
                    var data = await Processor.GetPCsByWSversion(version);

                    return Results.Ok(data);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            });

            app.Run();
        }
    }
}