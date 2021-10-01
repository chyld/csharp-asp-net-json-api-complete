using Microsoft.EntityFrameworkCore;

namespace web
{
  public class Database : DbContext
  {
    public DbSet<Comment> Comments { get; set; }
    public Database(DbContextOptions<Database> options) : base(options) { }
  }
}
