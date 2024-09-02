using Microsoft.EntityFrameworkCore;
namespace Library.Models
{
    public class StudySmartDbContext : DbContext
    {
        public DbSet<Data> About { get; set; }
        public StudySmartDbContext(DbContextOptions<StudySmartDbContext> options) : base(options) { }
    }
}
