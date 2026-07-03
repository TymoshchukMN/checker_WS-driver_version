using API_processor.Mappers;
using Microsoft.EntityFrameworkCore;

namespace API_processor.Classes
{
    public class VersionsContext(DbContextOptions<VersionsContext> options) : DbContext(options)
    {
        public DbSet<WSwersionData> WSwersionDatas => this.Set<WSwersionData>();
    }
}