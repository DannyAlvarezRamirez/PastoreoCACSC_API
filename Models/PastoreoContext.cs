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

        public virtual DbSet<Tbamcatagua> Tbamcataguas { get; set; } = null!;
        public virtual DbSet<TbamcatalertasConfiguracion> TbamcatalertasConfiguracions { get; set; } = null!;
        public virtual DbSet<Tbamcatalimento> Tbamcatalimentos { get; set; } = null!;
        public virtual DbSet<TbamcatcapacidadCarga> TbamcatcapacidadCargas { get; set; } = null!;
        public virtual DbSet<Tbamcatcodigo> Tbamcatcodigos { get; set; } = null!;
        public virtual DbSet<TbamcatcondicionesDrenaje> TbamcatcondicionesDrenajes { get; set; } = null!;
        public virtual DbSet<Tbamcatenergium> Tbamcatenergia { get; set; } = null!;
        public virtual DbSet<TbamcatequipoManejo> TbamcatequipoManejos { get; set; } = null!;
        public virtual DbSet<TbamcatestadoSalud> TbamcatestadoSaluds { get; set; } = null!;
        public virtual DbSet<TbamcatexposicionLuzSolar> TbamcatexposicionLuzSolars { get; set; } = null!;
        public virtual DbSet<Tbamcatfertilizante> Tbamcatfertilizantes { get; set; } = null!;
        public virtual DbSet<TbamcatfrecuenciaUso> TbamcatfrecuenciaUsos { get; set; } = null!;
        public virtual DbSet<TbamcatherbicidaPesticidum> TbamcatherbicidaPesticida { get; set; } = null!;
        public virtual DbSet<TbamcatherramientaMantenimiento> TbamcatherramientaMantenimientos { get; set; } = null!;
        public virtual DbSet<Tbamcatmedicamento> Tbamcatmedicamentos { get; set; } = null!;
        public virtual DbSet<TbamcatotroTipo> TbamcatotroTipos { get; set; } = null!;
        public virtual DbSet<Tbamcatproductividad> Tbamcatproductividads { get; set; } = null!;
        public virtual DbSet<Tbamcatraza> Tbamcatrazas { get; set; } = null!;
        public virtual DbSet<Tbamcatrole> Tbamcatroles { get; set; } = null!;
        public virtual DbSet<Tbamcatsexo> Tbamcatsexos { get; set; } = null!;
        public virtual DbSet<TbamcattipoPasto> TbamcattipoPastos { get; set; } = null!;
        public virtual DbSet<TbamcattipoTierra> TbamcattipoTierras { get; set; } = null!;
        public virtual DbSet<Tbamcattratamiento> Tbamcattratamientos { get; set; } = null!;
        public virtual DbSet<Tbamcatvacuna> Tbamcatvacunas { get; set; } = null!;
        public virtual DbSet<Tbamdetapartamento> Tbamdetapartamentos { get; set; } = null!;
        public virtual DbSet<TbamdetcodigosDet> TbamdetcodigosDets { get; set; } = null!;
        public virtual DbSet<Tbamdetganado> Tbamdetganados { get; set; } = null!;
        public virtual DbSet<Tbamdetsuministro> Tbamdetsuministros { get; set; } = null!;
        public virtual DbSet<Tbammaenotificacione> Tbammaenotificaciones { get; set; } = null!;
        public virtual DbSet<Tbammaereporte> Tbammaereportes { get; set; } = null!;
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
            modelBuilder.Entity<Tbamcatagua>(entity =>
            {
                entity.HasKey(e => e.AguaId)
                    .HasName("PK__TBAMCATA__9F3C6AFBACC66630");

                entity.ToTable("TBAMCATAgua");

                entity.Property(e => e.AguaId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.Notas).HasMaxLength(255);
            });

            modelBuilder.Entity<TbamcatalertasConfiguracion>(entity =>
            {
                entity.HasKey(e => e.AlertaId)
                    .HasName("PK__TBAMCATA__D9EF47C54E93DCE8");

                entity.ToTable("TBAMCATAlertasConfiguracion");

                entity.Property(e => e.AlertaId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.TipoAlerta).HasMaxLength(100);

                entity.Property(e => e.UsuarioId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.TbamcatalertasConfiguracions)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBAMCATAlertasConf_UsuarioId");
            });

            modelBuilder.Entity<Tbamcatalimento>(entity =>
            {
                entity.HasKey(e => e.AlimentoId)
                    .HasName("PK__TBAMCATA__7047A2B909E73380");

                entity.ToTable("TBAMCATAlimento");

                entity.Property(e => e.AlimentoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.Notas).HasMaxLength(255);
            });

            modelBuilder.Entity<TbamcatcapacidadCarga>(entity =>
            {
                entity.HasKey(e => e.CapacidadCargaId)
                    .HasName("PK__TBAMCATC__0F6974DE98612756");

                entity.ToTable("TBAMCATCapacidadCarga");

                entity.Property(e => e.CapacidadCargaId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);
            });

            modelBuilder.Entity<Tbamcatcodigo>(entity =>
            {
                entity.HasKey(e => e.CodigoId)
                    .HasName("PK__TBCMCATC__DB319C13EC078DB2");

                entity.ToTable("TBAMCATCodigos");

                entity.Property(e => e.CodigoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(250);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);
            });

            modelBuilder.Entity<TbamcatcondicionesDrenaje>(entity =>
            {
                entity.HasKey(e => e.CondicionDrenajeId)
                    .HasName("PK__TBAMCATC__64F8BDFE77371042");

                entity.ToTable("TBAMCATCondicionesDrenaje");

                entity.Property(e => e.CondicionDrenajeId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);
            });

            modelBuilder.Entity<Tbamcatenergium>(entity =>
            {
                entity.HasKey(e => e.EnergiaId)
                    .HasName("PK__TBAMCATE__B7349E4CE576A3A5");

                entity.ToTable("TBAMCATEnergia");

                entity.Property(e => e.EnergiaId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.Notas).HasMaxLength(255);
            });

            modelBuilder.Entity<TbamcatequipoManejo>(entity =>
            {
                entity.HasKey(e => e.EquipoManejoId)
                    .HasName("PK__TBAMCATE__87AF62BDD964E3DD");

                entity.ToTable("TBAMCATEquipoManejo");

                entity.Property(e => e.EquipoManejoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.Notas).HasMaxLength(255);
            });

            modelBuilder.Entity<TbamcatestadoSalud>(entity =>
            {
                entity.HasKey(e => e.EstadoSaludId)
                    .HasName("PK__TBAMCATE__A3593E8ACA3E9A71");

                entity.ToTable("TBAMCATEstadoSalud");

                entity.Property(e => e.EstadoSaludId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);
            });

            modelBuilder.Entity<TbamcatexposicionLuzSolar>(entity =>
            {
                entity.HasKey(e => e.ExposicionLuzSolarId)
                    .HasName("PK__TBAMCATE__E7D0DD5E68B8284C");

                entity.ToTable("TBAMCATExposicionLuzSolar");

                entity.Property(e => e.ExposicionLuzSolarId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);
            });

            modelBuilder.Entity<Tbamcatfertilizante>(entity =>
            {
                entity.HasKey(e => e.FertilizanteId)
                    .HasName("PK__TBAMCATF__F492E88CD14559D2");

                entity.ToTable("TBAMCATFertilizante");

                entity.Property(e => e.FertilizanteId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.Notas).HasMaxLength(255);
            });

            modelBuilder.Entity<TbamcatfrecuenciaUso>(entity =>
            {
                entity.HasKey(e => e.FrecuenciaUsoId)
                    .HasName("PK__TBAMCATF__70A4D5EBD9CF8061");

                entity.ToTable("TBAMCATFrecuenciaUso");

                entity.Property(e => e.FrecuenciaUsoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);
            });

            modelBuilder.Entity<TbamcatherbicidaPesticidum>(entity =>
            {
                entity.HasKey(e => e.HerbicidaPesticidaId)
                    .HasName("PK__TBAMCATH__366502A40E8D6AD0");

                entity.ToTable("TBAMCATHerbicidaPesticida");

                entity.Property(e => e.HerbicidaPesticidaId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.Notas).HasMaxLength(255);
            });

            modelBuilder.Entity<TbamcatherramientaMantenimiento>(entity =>
            {
                entity.HasKey(e => e.HerramientaMantenimientoId)
                    .HasName("PK__TBAMCATH__CC3A236734181375");

                entity.ToTable("TBAMCATHerramientaMantenimiento");

                entity.Property(e => e.HerramientaMantenimientoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.Notas).HasMaxLength(255);
            });

            modelBuilder.Entity<Tbamcatmedicamento>(entity =>
            {
                entity.HasKey(e => e.MedicamentoId)
                    .HasName("PK__TBAMCATM__003D65D3B0234741");

                entity.ToTable("TBAMCATMedicamento");

                entity.Property(e => e.MedicamentoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.Notas).HasMaxLength(255);
            });

            modelBuilder.Entity<TbamcatotroTipo>(entity =>
            {
                entity.HasKey(e => e.OtroTipoId)
                    .HasName("PK__TBAMCATO__D996648F3A30735B");

                entity.ToTable("TBAMCATOtroTipo");

                entity.Property(e => e.OtroTipoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.Notas).HasMaxLength(255);
            });

            modelBuilder.Entity<Tbamcatproductividad>(entity =>
            {
                entity.HasKey(e => e.ProductividadId)
                    .HasName("PK__TBAMCATP__411134744198B837");

                entity.ToTable("TBAMCATProductividad");

                entity.Property(e => e.ProductividadId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);
            });

            modelBuilder.Entity<Tbamcatraza>(entity =>
            {
                entity.HasKey(e => e.RazaId)
                    .HasName("PK__TBAMCATR__39A423D85AD2566F");

                entity.ToTable("TBAMCATRaza");

                entity.Property(e => e.RazaId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);
            });

            modelBuilder.Entity<Tbamcatrole>(entity =>
            {
                entity.HasKey(e => e.RolId)
                    .HasName("PK__TBAMCATR__F92302F17EE46E08");

                entity.ToTable("TBAMCATRoles");

                entity.Property(e => e.RolId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(250);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);
            });

            modelBuilder.Entity<Tbamcatsexo>(entity =>
            {
                entity.HasKey(e => e.SexoId)
                    .HasName("PK__TBAMCATS__876D94DE2BD6A956");

                entity.ToTable("TBAMCATSexo");

                entity.Property(e => e.SexoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);
            });

            modelBuilder.Entity<TbamcattipoPasto>(entity =>
            {
                entity.HasKey(e => e.TipoPastoId)
                    .HasName("PK__TBAMCATT__6C9E6F05A6332EBA");

                entity.ToTable("TBAMCATTipoPasto");

                entity.Property(e => e.TipoPastoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.Notas).HasMaxLength(255);
            });

            modelBuilder.Entity<TbamcattipoTierra>(entity =>
            {
                entity.HasKey(e => e.TipoTierraId)
                    .HasName("PK__TBAMCATT__893C8BC5BA715BDA");

                entity.ToTable("TBAMCATTipoTierra");

                entity.Property(e => e.TipoTierraId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);
            });

            modelBuilder.Entity<Tbamcattratamiento>(entity =>
            {
                entity.HasKey(e => e.TratamientoId)
                    .HasName("PK__TBAMCATT__6CFB2265FD363182");

                entity.ToTable("TBAMCATTratamientos");

                entity.Property(e => e.TratamientoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);
            });

            modelBuilder.Entity<Tbamcatvacuna>(entity =>
            {
                entity.HasKey(e => e.VacunaId)
                    .HasName("PK__TBAMCATV__DCE44CDF5A04AD81");

                entity.ToTable("TBAMCATVacuna");

                entity.Property(e => e.VacunaId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.Notas).HasMaxLength(255);
            });

            modelBuilder.Entity<Tbamdetapartamento>(entity =>
            {
                entity.HasKey(e => e.ApartamentoId)
                    .HasName("PK__TBAMCATA__9195254EE4BFBEFC");

                entity.ToTable("TBAMDETApartamentos");

                entity.HasIndex(e => e.ApartamentoId, "IDX_TBAMDETApartamentos_ApartamentoId");

                entity.Property(e => e.ApartamentoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CapacidadCargaId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CondicionDrenajeId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.ExposicionLuzSolarId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FrecuenciaUsoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.TamanoArea).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TipoPastoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TipoTierraId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.CapacidadCarga)
                    .WithMany(p => p.Tbamdetapartamentos)
                    .HasForeignKey(d => d.CapacidadCargaId)
                    .HasConstraintName("FK_TBAMCATApartamentos_CapacidadCarga");

                entity.HasOne(d => d.CondicionDrenaje)
                    .WithMany(p => p.Tbamdetapartamentos)
                    .HasForeignKey(d => d.CondicionDrenajeId)
                    .HasConstraintName("FK_TBAMCATApartamentos_CondicionDrenaje");

                entity.HasOne(d => d.ExposicionLuzSolar)
                    .WithMany(p => p.Tbamdetapartamentos)
                    .HasForeignKey(d => d.ExposicionLuzSolarId)
                    .HasConstraintName("FK_TBAMCATApartamentos_ExposicionLuzSolar");

                entity.HasOne(d => d.FrecuenciaUso)
                    .WithMany(p => p.Tbamdetapartamentos)
                    .HasForeignKey(d => d.FrecuenciaUsoId)
                    .HasConstraintName("FK_TBAMCATApartamentos_FrecuenciaUso");

                entity.HasOne(d => d.TipoPasto)
                    .WithMany(p => p.Tbamdetapartamentos)
                    .HasForeignKey(d => d.TipoPastoId)
                    .HasConstraintName("FK_TBAMCATApartamentos_TipoPasto");

                entity.HasOne(d => d.TipoTierra)
                    .WithMany(p => p.Tbamdetapartamentos)
                    .HasForeignKey(d => d.TipoTierraId)
                    .HasConstraintName("FK_TBAMCATApartamentos_TipoTierra");
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

            modelBuilder.Entity<Tbamdetganado>(entity =>
            {
                entity.HasKey(e => e.GanadoId)
                    .HasName("PK__TBAMDETG__A2E8B3B3334826DE");

                entity.ToTable("TBAMDETGanado");

                entity.HasIndex(e => e.EstadoSaludId, "IDX_TBAMDETGanado_EstadoSaludId");

                entity.HasIndex(e => e.GanadoId, "IDX_TBAMDETGanado_GanadoId");

                entity.HasIndex(e => e.ProductividadId, "IDX_TBAMDETGanado_ProductividadId");

                entity.HasIndex(e => e.RazaId, "IDX_TBAMDETGanado_RazaId");

                entity.HasIndex(e => e.SexoId, "IDX_TBAMDETGanado_SexoId");

                entity.HasIndex(e => e.TratamientoId, "IDX_TBAMDETGanado_TratamientoId");

                entity.Property(e => e.GanadoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.EstadoSaludId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.FechaUltimoChequeo).HasColumnType("date");

                entity.Property(e => e.IdentificacionUnica).HasMaxLength(50);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.Peso).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductividadId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RazaId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SexoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TratamientoId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.EstadoSalud)
                    .WithMany(p => p.Tbamdetganados)
                    .HasForeignKey(d => d.EstadoSaludId);

                entity.HasOne(d => d.Productividad)
                    .WithMany(p => p.Tbamdetganados)
                    .HasForeignKey(d => d.ProductividadId);

                entity.HasOne(d => d.Raza)
                    .WithMany(p => p.Tbamdetganados)
                    .HasForeignKey(d => d.RazaId);

                entity.HasOne(d => d.Sexo)
                    .WithMany(p => p.Tbamdetganados)
                    .HasForeignKey(d => d.SexoId);

                entity.HasOne(d => d.Tratamiento)
                    .WithMany(p => p.Tbamdetganados)
                    .HasForeignKey(d => d.TratamientoId);
            });

            modelBuilder.Entity<Tbamdetsuministro>(entity =>
            {
                entity.HasKey(e => e.SuministroId)
                    .HasName("PK__TBAMDETS__FDCAEC2D815C1D7F");

                entity.ToTable("TBAMDETSuministros");

                entity.Property(e => e.SuministroId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AguaId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AlimentoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.EnergiaId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EquipoManejoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FertilizanteId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.HerbicidaPesticidaId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.HerramientaMantenimientoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MedicamentoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.OtroTipoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TipoPastoId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VacunaId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Agua)
                    .WithMany(p => p.Tbamdetsuministros)
                    .HasForeignKey(d => d.AguaId)
                    .HasConstraintName("FK_TBAMDETSuministros_AguaId");

                entity.HasOne(d => d.Alimento)
                    .WithMany(p => p.Tbamdetsuministros)
                    .HasForeignKey(d => d.AlimentoId)
                    .HasConstraintName("FK_TBAMDETSuministros_AlimentoId");

                entity.HasOne(d => d.Energia)
                    .WithMany(p => p.Tbamdetsuministros)
                    .HasForeignKey(d => d.EnergiaId)
                    .HasConstraintName("FK_TBAMDETSuministros_EnergiaId");

                entity.HasOne(d => d.EquipoManejo)
                    .WithMany(p => p.Tbamdetsuministros)
                    .HasForeignKey(d => d.EquipoManejoId)
                    .HasConstraintName("FK_TBAMDETSuministros_EquipoManejoId");

                entity.HasOne(d => d.Fertilizante)
                    .WithMany(p => p.Tbamdetsuministros)
                    .HasForeignKey(d => d.FertilizanteId)
                    .HasConstraintName("FK_TBAMDETSuministros_FertilizanteId");

                entity.HasOne(d => d.HerbicidaPesticida)
                    .WithMany(p => p.Tbamdetsuministros)
                    .HasForeignKey(d => d.HerbicidaPesticidaId)
                    .HasConstraintName("FK_TBAMDETSuministros_HerbicidaPesticidaId");

                entity.HasOne(d => d.HerramientaMantenimiento)
                    .WithMany(p => p.Tbamdetsuministros)
                    .HasForeignKey(d => d.HerramientaMantenimientoId)
                    .HasConstraintName("FK_TBAMDETSuministros_HerramientaMantenimientoId");

                entity.HasOne(d => d.Medicamento)
                    .WithMany(p => p.Tbamdetsuministros)
                    .HasForeignKey(d => d.MedicamentoId)
                    .HasConstraintName("FK_TBAMDETSuministros_MedicamentoId");

                entity.HasOne(d => d.OtroTipo)
                    .WithMany(p => p.Tbamdetsuministros)
                    .HasForeignKey(d => d.OtroTipoId)
                    .HasConstraintName("FK_TBAMDETSuministros_OtroTipoId");

                entity.HasOne(d => d.TipoPasto)
                    .WithMany(p => p.Tbamdetsuministros)
                    .HasForeignKey(d => d.TipoPastoId)
                    .HasConstraintName("FK_TBAMDETSuministros_TipoPastoId");

                entity.HasOne(d => d.Vacuna)
                    .WithMany(p => p.Tbamdetsuministros)
                    .HasForeignKey(d => d.VacunaId)
                    .HasConstraintName("FK_TBAMDETSuministros_VacunaId");
            });

            modelBuilder.Entity<Tbammaenotificacione>(entity =>
            {
                entity.HasKey(e => e.NotificacionId)
                    .HasName("PK__TBAMMAEN__BCC120243F548C7E");

                entity.ToTable("TBAMMAENotificaciones");

                entity.Property(e => e.NotificacionId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreadoPor).HasMaxLength(20);

                entity.Property(e => e.ModificadoPor).HasMaxLength(20);

                entity.Property(e => e.Prioridad).HasMaxLength(20);

                entity.Property(e => e.TipoNotificacion).HasMaxLength(100);

                entity.Property(e => e.UsuarioId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Tbammaenotificaciones)
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
                    .HasConstraintName("FK__TBCMRELSi__RolId__5DCAEF64");

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
