

using Microsoft.EntityFrameworkCore;
using Warehouse.Model;


namespace Warehouse.AplicationContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Request> Requests { get; set; }
        public DbSet<Storage> Storages { get; set; }
    }
}
