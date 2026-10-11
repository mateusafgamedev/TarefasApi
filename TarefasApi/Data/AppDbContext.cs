using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TarefasApi.Entities;

namespace TarefasApi.Data
{
    public class AppDbContext : IdentityDbContext<Usuario>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas => Set<Tarefa>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Usuario>().ToTable("Usuarios");
            builder.Entity<Usuario>(e =>
            {
                e.Property(u => u.Nome).IsRequired().HasMaxLength(100);
                e.Property(u => u.Sobrenome).IsRequired().HasMaxLength(100);
            });

            builder.Entity<Tarefa>(e =>
            {
                e.Property(t => t.Titulo).IsRequired().HasMaxLength(200);
                e.Property(t => t.Descricao).IsRequired().HasMaxLength(1000);
                e.Property(t => t.Status).IsRequired().HasMaxLength(50);

                e.HasIndex(t => new {t.UsuarioId, t.Status });

                e.HasOne(t =>t.Usuario)
                    .WithMany(u => u.Tarefas)
                    .HasForeignKey(t => t.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);

            });
        }
    }
}
