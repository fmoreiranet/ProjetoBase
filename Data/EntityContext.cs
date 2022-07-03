using Microsoft.EntityFrameworkCore;
using ProjetoBase.Models;

namespace ProjetoBase.Data
{
    public class EntityContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }

        public EntityContext(DbContextOptions<EntityContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Category>();
            modelBuilder.Entity<Message>();
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        // {
        // }
    }
}