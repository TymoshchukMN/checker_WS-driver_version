using API_processor.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Viewer_WS_driver_version.Classes
{
    public class VersionsContext : DbContext
    {
        public VersionsContext(DbContextOptions<VersionsContext> options) : base(options)
        {
        }

        public DbSet<WSwersionData> WSwersionDatas => this.Set<WSwersionData>();
    }
}

