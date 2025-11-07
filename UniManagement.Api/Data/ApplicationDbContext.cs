using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using UniManagement.Api.Entities;

namespace UniManagement.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Chamado> TbChamados { get; set; }
        public DbSet<Analista> TbAnalistas { get; set; }
        public DbSet<Funcionario> TbFuncionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chamado>(entity =>
            {
                entity.ToTable("TbChamados");
                entity.HasKey(e => e.Id_Chamado);
                entity.Property(e => e.Id_Chamado).ValueGeneratedOnAdd();
                entity.HasOne(d => d.Funcionario)
                      .WithMany(p => p.Chamados)
                      .HasForeignKey(d => d.Id_Matricula_Funcionario);
                entity.HasOne(d => d.Analista)
                      .WithMany(p => p.ChamadosAtribuidos)
                      .HasForeignKey(d => d.Id_Analista_Atribuido);
            });

            modelBuilder.Entity<Analista>(entity =>
            {
                entity.ToTable("TbAnalistas");
                entity.HasKey(e => e.Id_Analista);
                entity.Property(e => e.Id_Analista).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("TbFuncionarios");
                entity.HasKey(e => e.Id_Matricula);
                entity.Property(e => e.Id_Matricula).ValueGeneratedOnAdd();
            });
        }
    }
}