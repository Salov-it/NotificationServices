using Microsoft.EntityFrameworkCore;
using NotificationServices.Domain;

namespace Postgres.Application.Context
{
    public class PostgresContext : DbContext
    {
        public DbSet<Notification> Notification {  get; set; }

        public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public void CreateDatabaseIfNotExists()
        {
            // Проверка и создание базы данных
            if (!Database.CanConnect())
            {
                Database.EnsureCreated();
            }
        }
    }
}
