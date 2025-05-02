using Microsoft.EntityFrameworkCore;
using SGPP.Domain.Entities;

namespace SGPP.Infrastructure
{
    public class SGPPDbContext : DbContext
    {
        public SGPPDbContext(DbContextOptions<SGPPDbContext> options) : base(options) { }

        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<ProveedorTieneProducto> ProveedorTieneProducto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define the composite primary key for ProveedorTieneProducto
            modelBuilder.Entity<ProveedorTieneProducto>()
                .HasKey(r => new { r.IdProveedor, r.IdProducto });
        }
    }
}