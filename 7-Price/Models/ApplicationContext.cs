using Microsoft.EntityFrameworkCore;

namespace NewsParser.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<News> News{ get; set; }

        public ApplicationContext() => Database.EnsureCreated();

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }
    }
}
