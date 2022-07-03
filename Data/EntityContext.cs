using ProjetoBase.Models;
using Microsoft.EntityFrameworkCore;
using projetoBase.Models;

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

        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        // {
        //     options.UseNpgsql($"Host=localhost;Port=5432;Pooling=true;Database=Treinamento;User Id= postgres;Password=admin;");
        // }
    }
}