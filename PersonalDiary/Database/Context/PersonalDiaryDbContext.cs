using Microsoft.EntityFrameworkCore;
using PersonalDiary.Database.Models;

namespace PersonalDiary.Database.Context
{
    public class PersonalDiaryDbContext : DbContext
    {
        public PersonalDiaryDbContext (DbContextOptions<PersonalDiaryDbContext> options) : base (options)
        { }

        public DbSet<DailySummary> DailySummaries { get; set; }
    }
}
