﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace aeroporto.Models;

public partial class CompanhiaAereaContext : DbContext
{
    public CompanhiaAereaContext()
    {
    }

    public CompanhiaAereaContext(DbContextOptions<CompanhiaAereaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aeronave> Aeronaves { get; set; }

    public virtual DbSet<Aeroporto> Aeroportos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Escala> Escalas { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Passageiro> Passageiros { get; set; }

    public virtual DbSet<Poltrona> Poltronas { get; set; }

    public virtual DbSet<Voo> Voos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=companhia_aerea;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aeronave>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__aeronave__3213E83FA1BAA1DD");

            entity.ToTable("aeronave");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Modelo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("modelo");
            entity.Property(e => e.Poltronas).HasColumnName("poltronas");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Aeroporto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__aeroport__3213E83F8EE6AEA9");

            entity.ToTable("aeroporto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("bairro");
            entity.Property(e => e.Cidade)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cidade");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.Pais)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.Rua)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("rua");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cliente__3213E83FF838E51C");

            entity.ToTable("cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Endereco)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("endereco");
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.NumVoos).HasColumnName("num_voos");
            entity.Property(e => e.Telefone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Escala>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__escala__3213E83FA1C0579C");

            entity.ToTable("escala");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdAeroporto).HasColumnName("id_aeroporto");
            entity.Property(e => e.IdVoo).HasColumnName("id_voo");
            entity.Property(e => e.Saida)
                .HasColumnType("datetime")
                .HasColumnName("saida");

            entity.HasOne(d => d.IdAeroportoNavigation).WithMany(p => p.Escalas)
                .HasForeignKey(d => d.IdAeroporto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_aeroporto_escala");

            entity.HasOne(d => d.IdVooNavigation).WithMany(p => p.Escalas)
                .HasForeignKey(d => d.IdVoo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_voo_escala");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__horario__3213E83FA77924C2");

            entity.ToTable("horario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.FinalHorario).HasColumnName("final_horario");
            entity.Property(e => e.IdVoo).HasColumnName("id_voo");
            entity.Property(e => e.InicioHorario).HasColumnName("inicio_horario");

            entity.HasOne(d => d.IdVooNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdVoo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_voo_horario");
        });

        modelBuilder.Entity<Passageiro>(entity =>
        {
            entity.HasKey(e => new { e.IdCliente, e.IdVoo }).HasName("pk_client_voo");

            entity.ToTable("passageiro");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdVoo).HasColumnName("id_voo");
            entity.Property(e => e.IdPoltrona).HasColumnName("id_poltrona");
            entity.Property(e => e.Passagem).HasColumnName("passagem");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Passageiros)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_cliente_passageiro");

            entity.HasOne(d => d.IdPoltronaNavigation).WithMany(p => p.Passageiros)
                .HasForeignKey(d => d.IdPoltrona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_poltrona_passageiro");

            entity.HasOne(d => d.IdVooNavigation).WithMany(p => p.Passageiros)
                .HasForeignKey(d => d.IdVoo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_voo_passageiro");
        });

        modelBuilder.Entity<Poltrona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__poltrona__3213E83F05B9EAA6");

            entity.ToTable("poltrona");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Disponivel).HasColumnName("disponivel");
            entity.Property(e => e.IdAeronave).HasColumnName("id_aeronave");
            entity.Property(e => e.Localizacao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("localizacao");

            entity.HasOne(d => d.IdAeronaveNavigation).WithMany(p => p.PoltronasNavigation)
                .HasForeignKey(d => d.IdAeronave)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_aeronave_poltrona");
        });

        modelBuilder.Entity<Voo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__voo__3213E83F8D8753EC");

            entity.ToTable("voo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdAeronave).HasColumnName("id_aeronave");
            entity.Property(e => e.IdAeroportoDestino).HasColumnName("id_aeroporto_destino");
            entity.Property(e => e.IdAeroportoOrigem).HasColumnName("id_aeroporto_origem");
            entity.Property(e => e.PrevisaoChegada)
                .HasColumnType("datetime")
                .HasColumnName("previsao_chegada");
            entity.Property(e => e.Saida)
                .HasColumnType("datetime")
                .HasColumnName("saida");

            entity.HasOne(d => d.IdAeronaveNavigation).WithMany(p => p.Voos)
                .HasForeignKey(d => d.IdAeronave)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_aeronave_voo");

            entity.HasOne(d => d.IdAeroportoDestinoNavigation).WithMany(p => p.VooIdAeroportoDestinoNavigations)
                .HasForeignKey(d => d.IdAeroportoDestino)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_aeroporto_destino_voo");

            entity.HasOne(d => d.IdAeroportoOrigemNavigation).WithMany(p => p.VooIdAeroportoOrigemNavigations)
                .HasForeignKey(d => d.IdAeroportoOrigem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_aeroporto_origem_voo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
