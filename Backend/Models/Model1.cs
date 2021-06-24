namespace Backend.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<auditoria> auditoria { get; set; }
        public virtual DbSet<banco> banco { get; set; }
        public virtual DbSet<configuracion> configuracion { get; set; }
        public virtual DbSet<cuenta> cuenta { get; set; }
        public virtual DbSet<tipo_transaccion> tipo_transaccion { get; set; }
        public virtual DbSet<transaccion> transaccion { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<auditoria>()
                .Property(e => e.ip_consulta)
                .IsUnicode(false);

            modelBuilder.Entity<auditoria>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<banco>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<banco>()
                .HasMany(e => e.cuenta)
                .WithOptional(e => e.banco)
                .HasForeignKey(e => e.id_banco)
                .WillCascadeOnDelete();

            modelBuilder.Entity<configuracion>()
                .Property(e => e.porc_gmf)
                .HasPrecision(5, 2);

            modelBuilder.Entity<cuenta>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<cuenta>()
                .HasMany(e => e.transaccion)
                .WithOptional(e => e.cuenta)
                .HasForeignKey(e => e.id_cuenta_destino)
                .WillCascadeOnDelete();

            modelBuilder.Entity<tipo_transaccion>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<tipo_transaccion>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.usuario1)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .HasMany(e => e.cuenta)
                .WithOptional(e => e.usuario)
                .HasForeignKey(e => e.id_usuario)
                .WillCascadeOnDelete();
        }
    }
}
