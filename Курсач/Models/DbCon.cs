using Microsoft.EntityFrameworkCore;
namespace Курсач.Models
{
    public class DbCon : DbContext
    {
        public DbCon(DbContextOptions<DbCon> options)
            : base(options) { }
        public DbSet<Telefon> Telefons { get; set; }
    }
}
