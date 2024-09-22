using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PastoreoCACSC_API.Models
{
    public partial class PastoreoContext : DbContext
    {
        public PastoreoContext()
        {
        }

        public PastoreoContext(DbContextOptions<PastoreoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbamcatalertasConfig> TbamcatalertasConfigs { get; set; } = null!;
        public virtual DbSet<Tbamcatcodigo> Tbamcatcodigos { get; set; } = null!;
        public virtual DbSet<TbamdetcapaCarga> TbamdetcapaCargas { get; set; } = null!;
        public virtual DbSet<TbamdetcodigosDet> TbamdetcodigosDets { get; set; } = null!;
        public virtual DbSet<Tbamdetconsumible> Tbamdetconsumibles { get; set; } = null!;
        public virtual DbSet<Tbamdetdrenaje> Tbamdetdrenajes { get; set; } = null!;
        public virtual DbSet<Tbamdetequipo> Tbamdetequipos { get; set; } = null!;
        public virtual DbSet<TbamdetestadoSalud> TbamdetestadoSaluds { get; set; } = null!;
        public virtual DbSet<TbamdetexpoSolar> TbamdetexpoSolars { get; set; } = null!;
        public virtual DbSet<TbamdetfrecuenciaUso> TbamdetfrecuenciaUsos { get; set; } = null!;
        public virtual DbSet<Tbamdetproductividad> Tbamdetproductividads { get; set; } = null!;
        public virtual DbSet<Tbamdetquimico> Tbamdetquimicos { get; set; } = null!;
        public virtual DbSet<Tbamdetraza> Tbamdetrazas { get; set; } = null!;
        public virtual DbSet<Tbamdetrecurso> Tbamdetrecursos { get; set; } = null!;
        public virtual DbSet<Tbamdetrole> Tbamdetroles { get; set; } = null!;
        public virtual DbSet<Tbamdetsexo> Tbamdetsexos { get; set; } = null!;
        public virtual DbSet<TbamdettipoPasto> TbamdettipoPastos { get; set; } = null!;
        public virtual DbSet<TbamdettipoTierra> TbamdettipoTierras { get; set; } = null!;
        public virtual DbSet<Tbamdettratamiento> Tbamdettratamientos { get; set; } = null!;
        public virtual DbSet<Tbammaeapartamento> Tbammaeapartamentos { get; set; } = null!;
        public virtual DbSet<Tbammaeganado> Tbammaeganados { get; set; } = null!;
        public virtual DbSet<Tbammaenotificacion> Tbammaenotificacions { get; set; } = null!;
        public virtual DbSet<Tbammaereporte> Tbammaereportes { get; set; } = null!;
        public virtual DbSet<Tbammaesuministro> Tbammaesuministros { get; set; } = null!;
        public virtual DbSet<Tbammaeusuario> Tbammaeusuarios { get; set; } = null!;
        public virtual DbSet<Tbamrelrotacion> Tbamrelrotacions { get; set; } = null!;
        public virtual DbSet<TbamrelsistUsuario> TbamrelsistUsuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local)\\sqlexpress;Database=PastoreoCACSC;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbamcatalertasConfig>(entity =>
            {
                entity.HasKey(e => e.AlertaId)
                    .HasName("PK__TBAMCATA__D9EF47C54E93DCE8");

                entity.ToTable("TBAMCATAlertasConfig");

                entity.Property(e => e.AlertaId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TipoAlerta).HasMaxLength(100);

                entity.Property(e => e.UsuarioId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.TbamcatalertasConfigs)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBAMCATAlertasConf_UsuarioId");
            });

            modelBuilder.Entity<Tbamcatcodigo>(entity =>
            {
                entity.HasKey(e => e.CodigoId)
                    .HasName("PK__TBCMCATC__DB319C13EC078DB2");

                entity.ToTable("TBAMCATCodigos");

                entity.Property(e => e.CodigoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Descripcion).HasMaxLength(250);
            });

            modelBuilder.Entity<TbamdetcapaCarga>(entity =>
            {
                entity.HasKey(e => e.CapaCargaId)
                    .HasName("PK__TBAMDETC__539E0334B5D54C76");

                entity.ToTable("TBAMDETCapaCarga");

                entity.Property(e => e.CapaCargaId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<TbamdetcodigosDet>(entity =>
            {
                entity.HasKey(e => new { e.CodigoId, e.CodigoDetId })
                    .HasName("PK__TBCMDETC__3C7B3B779810A650");

                entity.ToTable("TBAMDETCodigosDet");

                entity.Property(e => e.CodigoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CodigoDetId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(250);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.HasOne(d => d.Codigo)
                    .WithMany(p => p.TbamdetcodigosDets)
                    .HasForeignKey(d => d.CodigoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TBCMDETCo__Codig__4F7CD00D");
            });

            modelBuilder.Entity<Tbamdetconsumible>(entity =>
            {
                entity.HasKey(e => e.ConsumibleId)
                    .HasName("PK__TBAMDETC__E9D4955A349835E9");

                entity.ToTable("TBAMDETConsumibles");

                entity.Property(e => e.Detalles).HasMaxLength(255);

                entity.Property(e => e.SuministroId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TipoConsumible).HasMaxLength(100);

                entity.HasOne(d => d.Suministro)
                    .WithMany(p => p.Tbamdetconsumibles)
                    .HasForeignKey(d => d.SuministroId)
                    .HasConstraintName("FK__TBAMDETCo__Sumin__1E6F845E");
            });

            modelBuilder.Entity<Tbamdetdrenaje>(entity =>
            {
                entity.HasKey(e => e.DrenajeId)
                    .HasName("PK__TBAMDETD__B5F77BF212E3D4BE");

                entity.ToTable("TBAMDETDrenaje");

                entity.Property(e => e.DrenajeId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<Tbamdetequipo>(entity =>
            {
                entity.HasKey(e => e.EquipoId)
                    .HasName("PK__TBAMDETE__DE8A0BDF40FADAB7");

                entity.ToTable("TBAMDETEquipo");

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.Marca).HasMaxLength(100);

                entity.Property(e => e.SuministroId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TipoEquipo).HasMaxLength(100);

                entity.HasOne(d => d.Suministro)
                    .WithMany(p => p.Tbamdetequipos)
                    .HasForeignKey(d => d.SuministroId)
                    .HasConstraintName("FK__TBAMDETEq__Sumin__214BF109");
            });

            modelBuilder.Entity<TbamdetestadoSalud>(entity =>
            {
                entity.HasKey(e => e.EstadoSaludId)
                    .HasName("PK__TBAMDETE__876D94DE463971B2");

                entity.ToTable("TBAMDETEstadoSalud");

                entity.Property(e => e.EstadoSaludId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<TbamdetexpoSolar>(entity =>
            {
                entity.HasKey(e => e.ExpoSolarId)
                    .HasName("PK__TBAMDETE__46056A20C15BB81C");

                entity.ToTable("TBAMDETExpoSolar");

                entity.Property(e => e.ExpoSolarId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<TbamdetfrecuenciaUso>(entity =>
            {
                entity.HasKey(e => e.FrecuenciaUsoId)
                    .HasName("PK__TBAMDETF__70A4D5EBF4FD791A");

                entity.ToTable("TBAMDETFrecuenciaUso");

                entity.Property(e => e.FrecuenciaUsoId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<Tbamdetproductividad>(entity =>
            {
                entity.HasKey(e => e.ProductividadId)
                    .HasName("PK__TBAMDETP__41113474AD56BC9A");

                entity.ToTable("TBAMDETProductividad");

                entity.Property(e => e.ProductividadId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<Tbamdetquimico>(entity =>
            {
                entity.HasKey(e => e.QuimicoId)
                    .HasName("PK__TBAMDETQ__F8D6E15ACAB98E1E");

                entity.ToTable("TBAMDETQuimicos");

                entity.Property(e => e.Aplicacion).HasMaxLength(255);

                entity.Property(e => e.SuministroId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TipoQuimico).HasMaxLength(100);

                entity.HasOne(d => d.Suministro)
                    .WithMany(p => p.Tbamdetquimicos)
                    .HasForeignKey(d => d.SuministroId)
                    .HasConstraintName("FK__TBAMDETQu__Sumin__24285DB4");
            });

            modelBuilder.Entity<Tbamdetraza>(entity =>
            {
                entity.HasKey(e => e.RazaId)
                    .HasName("PK__TBAMCATR__39A423D857775E00");

                entity.ToTable("TBAMDETRaza");

                entity.Property(e => e.RazaId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<Tbamdetrecurso>(entity =>
            {
                entity.HasKey(e => e.RecursoId)
                    .HasName("PK__TBAMDETR__82F2B18498D13544");

                entity.ToTable("TBAMDETRecursos");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Detalles).HasMaxLength(255);

                entity.Property(e => e.SuministroId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TipoRecurso).HasMaxLength(100);

                entity.HasOne(d => d.Suministro)
                    .WithMany(p => p.Tbamdetrecursos)
                    .HasForeignKey(d => d.SuministroId)
                    .HasConstraintName("FK__TBAMDETRe__Sumin__2704CA5F");
            });

            modelBuilder.Entity<Tbamdetrole>(entity =>
            {
                entity.HasKey(e => e.RolId)
                    .HasName("PK__TBAMDETR__F92302F13F56D465");

                entity.ToTable("TBAMDETRoles");

                entity.Property(e => e.RolId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion).HasMaxLength(250);
            });

            modelBuilder.Entity<Tbamdetsexo>(entity =>
            {
                entity.HasKey(e => e.SexoId)
                    .HasName("PK__TBAMDETS__876D94DEA1C47947");

                entity.ToTable("TBAMDETSexo");

                entity.Property(e => e.SexoId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<TbamdettipoPasto>(entity =>
            {
                entity.HasKey(e => e.TipoPastoId)
                    .HasName("PK__TBAMDETT__6C9E6F05D9C45629");

                entity.ToTable("TBAMDETTipoPasto");

                entity.Property(e => e.TipoPastoId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<TbamdettipoTierra>(entity =>
            {
                entity.HasKey(e => e.TipoTierraId)
                    .HasName("PK__TBAMDETT__893C8BC57F56D7E6");

                entity.ToTable("TBAMDETTipoTierra");

                entity.Property(e => e.TipoTierraId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<Tbamdettratamiento>(entity =>
            {
                entity.HasKey(e => e.TratamientoId)
                    .HasName("PK__TBAMDETT__6CFB2265E5E80D6F");

                entity.ToTable("TBAMDETTratamientos");

                entity.Property(e => e.TratamientoId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<Tbammaeapartamento>(entity =>
            {
                entity.HasKey(e => e.ApartamentoId)
                    .HasName("PK__TBAMCATA__9195254EE4BFBEFC");

                entity.ToTable("TBAMMAEApartamentos");

                entity.HasIndex(e => e.ApartamentoId, "IDX_TBAMDETApartamentos_ApartamentoId");

                entity.Property(e => e.ApartamentoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CapaCargaId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.DrenajeId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ExpoSolarId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FrecuenciaUsoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.TamanoArea).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TipoPastoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TipoTierraId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.CapaCarga)
                    .WithMany(p => p.Tbammaeapartamentos)
                    .HasForeignKey(d => d.CapaCargaId);

                entity.HasOne(d => d.Drenaje)
                    .WithMany(p => p.Tbammaeapartamentos)
                    .HasForeignKey(d => d.DrenajeId);

                entity.HasOne(d => d.ExpoSolar)
                    .WithMany(p => p.Tbammaeapartamentos)
                    .HasForeignKey(d => d.ExpoSolarId);

                entity.HasOne(d => d.FrecuenciaUso)
                    .WithMany(p => p.Tbammaeapartamentos)
                    .HasForeignKey(d => d.FrecuenciaUsoId);

                entity.HasOne(d => d.TipoPasto)
                    .WithMany(p => p.Tbammaeapartamentos)
                    .HasForeignKey(d => d.TipoPastoId);

                entity.HasOne(d => d.TipoTierra)
                    .WithMany(p => p.Tbammaeapartamentos)
                    .HasForeignKey(d => d.TipoTierraId);
            });

            modelBuilder.Entity<Tbammaeganado>(entity =>
            {
                entity.HasKey(e => e.GanadoId)
                    .HasName("PK__TBAMDETG__A2E8B3B3334826DE");

                entity.ToTable("TBAMMAEGanado");

                entity.Property(e => e.GanadoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.EstadoSaludId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.FechaUltimoChequeo).HasColumnType("date");

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.Peso).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductividadId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RazaId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SexoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TratamientoId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.EstadoSalud)
                    .WithMany(p => p.Tbammaeganados)
                    .HasForeignKey(d => d.EstadoSaludId);

                entity.HasOne(d => d.Productividad)
                    .WithMany(p => p.Tbammaeganados)
                    .HasForeignKey(d => d.ProductividadId);

                entity.HasOne(d => d.Raza)
                    .WithMany(p => p.Tbammaeganados)
                    .HasForeignKey(d => d.RazaId);

                entity.HasOne(d => d.Sexo)
                    .WithMany(p => p.Tbammaeganados)
                    .HasForeignKey(d => d.SexoId);

                entity.HasOne(d => d.Tratamiento)
                    .WithMany(p => p.Tbammaeganados)
                    .HasForeignKey(d => d.TratamientoId);
            });

            modelBuilder.Entity<Tbammaenotificacion>(entity =>
            {
                entity.HasKey(e => e.NotificacionId)
                    .HasName("PK__TBAMMAEN__BCC120243F548C7E");

                entity.ToTable("TBAMMAENotificacion");

                entity.Property(e => e.NotificacionId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.Prioridad).HasMaxLength(20);

                entity.Property(e => e.TipoNotificacion).HasMaxLength(100);

                entity.Property(e => e.UsuarioId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Tbammaenotificacions)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBAMMAENotificaciones_UsuarioId");
            });

            modelBuilder.Entity<Tbammaereporte>(entity =>
            {
                entity.HasKey(e => e.ReporteId)
                    .HasName("PK__TBAMMAER__0B29EA6E2F3E1049");

                entity.ToTable("TBAMMAEReportes");

                entity.Property(e => e.ReporteId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.TipoReporte).HasMaxLength(50);

                entity.Property(e => e.UsuarioId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Tbammaereportes)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBAMMAEReportes_UsuarioId");
            });

            modelBuilder.Entity<Tbammaesuministro>(entity =>
            {
                entity.HasKey(e => e.SuministroId)
                    .HasName("PK__TBAMMAES__FDCAEC2D9D42FFBC");

                entity.ToTable("TBAMMAESuministros");

                entity.Property(e => e.SuministroId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(255);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.TipoSuministro).HasMaxLength(100);
            });

            modelBuilder.Entity<Tbammaeusuario>(entity =>
            {
                entity.ToTable("TBAMMAEUsuarios");

                entity.HasIndex(e => e.Id, "IDX_TBAMMAEUsuarios_UsuarioId");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AccountStatus).HasMaxLength(20);

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Estado).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Idnumber)
                    .HasMaxLength(20)
                    .HasColumnName("IDNumber");

                entity.Property(e => e.LastAccess).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.PasswordHash).HasMaxLength(256);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.RolId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Tbamrelrotacion>(entity =>
            {
                entity.HasKey(e => e.RotacionId)
                    .HasName("PK__TBAMRELR__CF4EAADBF64AEE20");

                entity.ToTable("TBAMRELRotacion");

                entity.Property(e => e.RotacionId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ApartamentoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.EficienciaPastoreo).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.Temporada).HasMaxLength(50);

                entity.Property(e => e.TipoGanado).HasMaxLength(50);

                entity.HasOne(d => d.Apartamento)
                    .WithMany(p => p.Tbamrelrotacions)
                    .HasForeignKey(d => d.ApartamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBAMRELRotacion_ApartamentoId");
            });

            modelBuilder.Entity<TbamrelsistUsuario>(entity =>
            {
                entity.HasKey(e => new { e.SystemId, e.UsuarioId })
                    .HasName("PK__TBCMRELS__012728F1D53F15C8");

                entity.ToTable("TBAMRELSistUsuarios");

                entity.Property(e => e.UsuarioId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.EstadoId).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.RolId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.TbamrelsistUsuarios)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTBAMRELSistUsuarios_TBAMDETRoles_RolId");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.TbamrelsistUsuarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TBCMRELSi__Usuar__5CD6CB2B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
