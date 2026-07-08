using VersionStorage.Mappers;
using Microsoft.EntityFrameworkCore;

namespace VersionStorage.Classes
{
    public class VersionsContext : DbContext
    {
        public VersionsContext(DbContextOptions<VersionsContext> options) : base(options)
        {
        }

        public DbSet<WSwersionData> WSwersionDatas => this.Set<WSwersionData>();
    }
}

