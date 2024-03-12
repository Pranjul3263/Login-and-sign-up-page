using Microsoft.EntityFrameworkCore;

namespace Registration_Login.Models
{
    public class RegistrationDbContext : DbContext
    {
        public RegistrationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<TableModel> tableModels { get; set; }
    }
}
