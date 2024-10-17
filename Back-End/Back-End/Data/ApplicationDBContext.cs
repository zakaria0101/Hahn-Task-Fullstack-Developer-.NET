using Microsoft.EntityFrameworkCore;
using Back_End.Models;

namespace Back_End.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Ticket> Ticket { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .Property(t => t.Ticket_ID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1000, 1);

            base.OnModelCreating(modelBuilder);
        }
    }
}
