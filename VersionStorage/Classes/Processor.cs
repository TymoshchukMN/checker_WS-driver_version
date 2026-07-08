using VersionStorage.Mappers;
using Microsoft.EntityFrameworkCore;

namespace VersionStorage.Classes
{
    public static class Processor
    {
        private const string DbPath = "C:\\microservices\\WS_driwer_reporter\\WSVersions.db";

        public static async Task DBCkeck()
        {
            var option = new DbContextOptionsBuilder<VersionsContext>();
            option.UseSqlite($"Data Source={DbPath}");

            using var db = new VersionsContext(option.Options);

            await db.Database.EnsureCreatedAsync();
        }

        public static IEnumerable<WSwersionData> GetWSversions()
        {
            var option = new DbContextOptionsBuilder<VersionsContext>();
            option.UseSqlite($"Data Source={DbPath}");

            using var db = new VersionsContext(option.Options);

            var data = db.WSwersionDatas;

            return data.ToList();
        }

        public static async Task AddData(WSwersionData data)
        {
            var option = new DbContextOptionsBuilder<VersionsContext>();
            option.UseSqlite($"Data Source={DbPath}");

            using var db = new VersionsContext(option.Options);

            var pc = await db.WSwersionDatas.FindAsync(data.ComputerName);

            if (pc == null)
            {
                db.WSwersionDatas.Add(data);
            }
            else
            {
                pc.CheckDate = data.CheckDate;
                pc.FileVersion = data.FileVersion;
                pc.IsFileExists = data.IsFileExists;

            }
            await db.SaveChangesAsync();
        }

        public static async Task<IEnumerable<WScountByPC>> GetWSCountByPC()
        {
            var option = new DbContextOptionsBuilder<VersionsContext>();

            option.UseSqlite($"Data Source={DbPath}");

            using var db = new VersionsContext(option.Options);

            var data = await db.WSwersionDatas
                .GroupBy(x => x.FileVersion)
                .Select(x => new WScountByPC()
                {
                    FileVersion = x.Key,
                    Count = x.Count()
                })
                .ToListAsync();

            return data.ToList();
        }

        public static async Task<IEnumerable<WSwersionData>> GetPCsByWSversion(string version)
        {
            var option = new DbContextOptionsBuilder<VersionsContext>();

            option.UseSqlite($"Data source={DbPath}");
            using var db = new VersionsContext(option.Options);

            var data = await db.WSwersionDatas.Where(v => v.FileVersion == version).Select(x => x).ToListAsync();

            return data.ToList();
        }
    }
}