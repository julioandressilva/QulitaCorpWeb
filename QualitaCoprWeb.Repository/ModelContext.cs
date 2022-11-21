using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QualitaCorpWeb.Entities.Models;
using QualitaCorpWeb.Repository.Contracts;

namespace QualitaCoprWeb.Repository.Models
{
    public partial class ModelContext : DbContext, IModelContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Detallefactura> Detallefacturas { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Mesa> Mesas { get; set; } = null!;
        public virtual DbSet<Mesero> Meseros { get; set; } = null!;
        public virtual DbSet<Supervisor> Supervisors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=MERCM_ADMINIS;Password=MERCM_ADMINIS;Data Source=10.240.238.69:1521/ORADEV11;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MERCM_ADMINIS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("SYS_C00186767");

                entity.ToTable("CLIENTE");

                entity.Property(e => e.Idcliente)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDCLIENTE");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOS");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRES");

                entity.Property(e => e.Telefono)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TELEFONO");
            });

            modelBuilder.Entity<Detallefactura>(entity =>
            {
                entity.HasKey(e => e.Iddetallefactura)
                    .HasName("SYS_C00186780");

                entity.ToTable("DETALLEFACTURA");

                entity.Property(e => e.Iddetallefactura)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDDETALLEFACTURA");

                entity.Property(e => e.Idfactura)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDFACTURA");

                entity.Property(e => e.Idsupervisor)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDSUPERVISOR");

                entity.Property(e => e.Plato)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PLATO");

                entity.Property(e => e.Valor)
                    .HasColumnType("NUMBER")
                    .HasColumnName("VALOR");

                entity.HasOne(d => d.IdfacturaNavigation)
                    .WithMany(p => p.Detallefacturas)
                    .HasForeignKey(d => d.Idfactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C00186784");

                entity.HasOne(d => d.IdsupervisorNavigation)
                    .WithMany(p => p.Detallefacturas)
                    .HasForeignKey(d => d.Idsupervisor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C00186785");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.Idfactura)
                    .HasName("SYS_C00186775");

                entity.ToTable("FACTURA");

                entity.Property(e => e.Idfactura)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDFACTURA");

                entity.Property(e => e.Fecha)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Idcliente)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDCLIENTE");

                entity.Property(e => e.Idmesa)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDMESA");

                entity.Property(e => e.Idmesero)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDMESERO");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C00186781");

                entity.HasOne(d => d.IdmesaNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.Idmesa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C00186782");

                entity.HasOne(d => d.IdmeseroNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.Idmesero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C00186783");
            });

            modelBuilder.Entity<Mesa>(entity =>
            {
                entity.HasKey(e => e.Idmesa)
                    .HasName("SYS_C00186769");

                entity.ToTable("MESA");

                entity.Property(e => e.Idmesa)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDMESA");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Puestos)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PUESTOS")
                    .IsFixedLength();

                entity.Property(e => e.Reservada)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RESERVADA");
            });

            modelBuilder.Entity<Mesero>(entity =>
            {
                entity.HasKey(e => e.Idmesero)
                    .HasName("SYS_C00186768");

                entity.ToTable("MESERO");

                entity.Property(e => e.Idmesero)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDMESERO");

                entity.Property(e => e.Antiguedad)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ANTIGUEDAD");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOS");

                entity.Property(e => e.Edad)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EDAD");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRES");
            });

            modelBuilder.Entity<Supervisor>(entity =>
            {
                entity.HasKey(e => e.Idsupervisor)
                    .HasName("SYS_C00186770");

                entity.ToTable("SUPERVISOR");

                entity.Property(e => e.Idsupervisor)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDSUPERVISOR");

                entity.Property(e => e.Antiguedad)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ANTIGUEDAD");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOS");

                entity.Property(e => e.Edad)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EDAD");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRES");
            });

            modelBuilder.HasSequence("ACT_WFM_SEQ");

            modelBuilder.HasSequence("CLIENTE_SEQ");

            modelBuilder.HasSequence("CMCC").IncrementsBy(-158);

            modelBuilder.HasSequence("DBINPUT_SEQUENCE");

            modelBuilder.HasSequence("DETFAC_SEQ");

            modelBuilder.HasSequence("FACTURA_SEQ");

            modelBuilder.HasSequence("ID_AVISO");

            modelBuilder.HasSequence("ID_ERROR");

            modelBuilder.HasSequence("ID_LOG");

            modelBuilder.HasSequence("ID_SIG");

            modelBuilder.HasSequence("INBOUND_SEQUENCE");

            modelBuilder.HasSequence("MEM_SCADA_EVENTOS_SEQ");

            modelBuilder.HasSequence("MEM_SEQ_AVISOS");

            modelBuilder.HasSequence("MEM_SEQ_ERRORES");

            modelBuilder.HasSequence("MESA_SEQ");

            modelBuilder.HasSequence("MESERO_SEQ");

            modelBuilder.HasSequence("SEQ_MCC");

            modelBuilder.HasSequence("SEQ_MEM_POME_PRONO");

            modelBuilder.HasSequence("SEQ_P_P");

            modelBuilder.HasSequence("SEQ_PP");

            modelBuilder.HasSequence("SUPERVISOR_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
