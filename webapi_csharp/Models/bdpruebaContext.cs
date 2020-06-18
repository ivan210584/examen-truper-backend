using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace webapi_csharp.Models
{
    public partial class bdpruebaContext : DbContext
    {
        public bdpruebaContext()
        {
        }

        public bdpruebaContext(DbContextOptions<bdpruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<PedidosDetalleW> PedidosDetalleW { get; set; }
        public virtual DbSet<PedidosW> PedidosW { get; set; }
        public virtual DbSet<ProductoW> ProductoW { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosW> UsuariosW { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=3.133.208.251 ; database=bdprueba ; user id = admin; password = ladesiempre;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.ToTable("Clientes", "guest");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PedidosDetalleW>(entity =>
            {
                entity.ToTable("PEDIDOS_DETALLE_W", "examen");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amout).HasColumnName("AMOUT");

                entity.Property(e => e.IdPedido).HasColumnName("ID_PEDIDO");

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.PedidosDetalleW)
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("PEDIDOS_W_PEDIDOS_DETALLE_W");

                entity.HasOne(d => d.SkuNavigation)
                    .WithMany(p => p.PedidosDetalleW)
                    .HasForeignKey(d => d.Sku)
                    .HasConstraintName("PRODUCTO_W_PEDIDOS_DETALLE_W");
            });

            modelBuilder.Entity<PedidosW>(entity =>
            {
                entity.ToTable("PEDIDOS_W", "examen");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateSale)
                    .HasColumnName("DATE_SALE")
                    .HasColumnType("date");

                entity.Property(e => e.Total).HasColumnName("TOTAL");

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.PedidosW)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("USUARIOS_W_PEDIDOS_W");
            });

            modelBuilder.Entity<ProductoW>(entity =>
            {
                entity.HasKey(e => e.Sku)
                    .HasName("PK__PRODUCTO__CA1ECF0CAF06C63A");

                entity.ToTable("PRODUCTO_W", "examen");

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Existencia).HasColumnName("EXISTENCIA");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("PRICE");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF971C4F9B37");

                entity.Property(e => e.IdUsuario).ValueGeneratedNever();

                entity.Property(e => e.NombreUsuario).IsRequired();
            });

            modelBuilder.Entity<UsuariosW>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__USUARIOS__B15BE12FC02462A2");

                entity.ToTable("USUARIOS_W", "examen");

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("APELLIDOS")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("ROLE")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
