using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EncuestasApp.Models;

public partial class EncuestasDbContext : DbContext
{
    public EncuestasDbContext()
    {
    }

    public EncuestasDbContext(DbContextOptions<EncuestasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Encuesta> Encuestas { get; set; }

    public virtual DbSet<OpcionesRespuestum> OpcionesRespuesta { get; set; }

    public virtual DbSet<Pregunta> Preguntas { get; set; }

    public virtual DbSet<Respuesta> Respuestas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-HBO2J7T;Database=EncuestasDB;uid=sa;pwd=123;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Encuesta>(entity =>
        {
            entity.HasKey(e => e.EncuestaId).HasName("PK__Encuesta__82FD78E81726A38E");

            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.Titulo).HasMaxLength(150);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Encuesta)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Encuestas__Usuar__267ABA7A");
        });

        modelBuilder.Entity<OpcionesRespuestum>(entity =>
        {
            entity.HasKey(e => e.OpcionId).HasName("PK__Opciones__77CD08635EC5F3FF");

            entity.Property(e => e.Texto).HasMaxLength(150);

            entity.HasOne(d => d.Pregunta).WithMany(p => p.OpcionesRespuesta)
                .HasForeignKey(d => d.PreguntaId)
                .HasConstraintName("FK__OpcionesR__Pregu__2C3393D0");
        });

        modelBuilder.Entity<Pregunta>(entity =>
        {
            entity.HasKey(e => e.PreguntaId).HasName("PK__Pregunta__EBB2A379882C2944");

            entity.Property(e => e.Texto).HasMaxLength(200);
            entity.Property(e => e.Tipo).HasMaxLength(50);

            entity.HasOne(d => d.Encuesta).WithMany(p => p.Pregunta)
                .HasForeignKey(d => d.EncuestaId)
                .HasConstraintName("FK__Preguntas__Encue__29572725");
        });

        modelBuilder.Entity<Respuesta>(entity =>
        {
            entity.HasKey(e => e.RespuestaId).HasName("PK__Respuest__31F7FC117785F7C5");

            entity.Property(e => e.TextoLibre).HasMaxLength(250);

            entity.HasOne(d => d.Opcion).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.OpcionId)
                .HasConstraintName("FK__Respuesta__Opcio__30F848ED");

            entity.HasOne(d => d.Pregunta).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.PreguntaId)
                .HasConstraintName("FK__Respuesta__Pregu__300424B4");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Respuesta__Usuar__2F10007B");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7B86EBC2927");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(200);
            entity.Property(e => e.Rol).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
