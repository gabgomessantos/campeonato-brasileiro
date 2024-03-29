﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using campeonato_brasileiro_data.Contexts;

#nullable disable

namespace campeonato_brasileiro_data.Migrations
{
    [DbContext(typeof(CampeonatoBrasileiroDbContext))]
    partial class CampeonatoBrasileiroDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("campeonato_brasileiro_business.Models.Evento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PartidaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TipoEvento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartidaId");

                    b.ToTable("Eventos", (string)null);
                });

            modelBuilder.Entity("campeonato_brasileiro_business.Models.Jogador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("TimeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TimeId");

                    b.ToTable("Jogadores", (string)null);
                });

            modelBuilder.Entity("campeonato_brasileiro_business.Models.Partida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TimeMandanteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TimeVisitanteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TorneioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TimeMandanteId");

                    b.HasIndex("TimeVisitanteId");

                    b.HasIndex("TorneioId");

                    b.ToTable("Partidas", (string)null);
                });

            modelBuilder.Entity("campeonato_brasileiro_business.Models.Time", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("Id");

                    b.ToTable("Times", (string)null);
                });

            modelBuilder.Entity("campeonato_brasileiro_business.Models.Torneio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("Id");

                    b.ToTable("Torneios", (string)null);
                });

            modelBuilder.Entity("campeonato_brasileiro_business.Models.Transferencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("JogadorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TimeDestinoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TimeOrigemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("JogadorId");

                    b.HasIndex("TimeDestinoId");

                    b.HasIndex("TimeOrigemId");

                    b.ToTable("Transferencias", (string)null);
                });

            modelBuilder.Entity("TimeTorneio", b =>
                {
                    b.Property<Guid>("TimesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TorneiosId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TimesId", "TorneiosId");

                    b.HasIndex("TorneiosId");

                    b.ToTable("TimeTorneio");
                });

            modelBuilder.Entity("campeonato_brasileiro_business.Models.Evento", b =>
                {
                    b.HasOne("campeonato_brasileiro_business.Models.Partida", "Partida")
                        .WithMany("Eventos")
                        .HasForeignKey("PartidaId")
                        .IsRequired();

                    b.Navigation("Partida");
                });

            modelBuilder.Entity("campeonato_brasileiro_business.Models.Jogador", b =>
                {
                    b.HasOne("campeonato_brasileiro_business.Models.Time", "Time")
                        .WithMany("Jogadores")
                        .HasForeignKey("TimeId")
                        .IsRequired();

                    b.Navigation("Time");
                });

            modelBuilder.Entity("campeonato_brasileiro_business.Models.Partida", b =>
                {
                    b.HasOne("campeonato_brasileiro_business.Models.Time", "TimeMandante")
                        .WithMany("Partidas")
                        .HasForeignKey("TimeMandanteId")
                        .IsRequired();

                    b.HasOne("campeonato_brasileiro_business.Models.Time", "TimeVisitante")
                        .WithMany()
                        .HasForeignKey("TimeVisitanteId")
                        .IsRequired();

                    b.HasOne("campeonato_brasileiro_business.Models.Torneio", "Torneio")
                        .WithMany("Partidas")
                        .HasForeignKey("TorneioId")
                        .IsRequired();

                    b.Navigation("TimeMandante");

                    b.Navigation("TimeVisitante");

                    b.Navigation("Torneio");
                });

            modelBuilder.Entity("campeonato_brasileiro_business.Models.Transferencia", b =>
                {
                    b.HasOne("campeonato_brasileiro_business.Models.Jogador", "Jogador")
                        .WithMany("Transferencias")
                        .HasForeignKey("JogadorId")
                        .IsRequired();

                    b.HasOne("campeonato_brasileiro_business.Models.Time", "TimeDestino")
                        .WithMany()
                        .HasForeignKey("TimeDestinoId")
                        .IsRequired();

                    b.HasOne("campeonato_brasileiro_business.Models.Time", "TimeOrigem")
                        .WithMany("Transferencias")
                        .HasForeignKey("TimeOrigemId")
                        .IsRequired();

                    b.Navigation("Jogador");

                    b.Navigation("TimeDestino");

                    b.Navigation("TimeOrigem");
                });

            modelBuilder.Entity("TimeTorneio", b =>
                {
                    b.HasOne("campeonato_brasileiro_business.Models.Time", null)
                        .WithMany()
                        .HasForeignKey("TimesId")
                        .IsRequired();

                    b.HasOne("campeonato_brasileiro_business.Models.Torneio", null)
                        .WithMany()
                        .HasForeignKey("TorneiosId")
                        .IsRequired();
                });

            modelBuilder.Entity("campeonato_brasileiro_business.Models.Jogador", b =>
                {
                    b.Navigation("Transferencias");
                });

            modelBuilder.Entity("campeonato_brasileiro_business.Models.Partida", b =>
                {
                    b.Navigation("Eventos");
                });

            modelBuilder.Entity("campeonato_brasileiro_business.Models.Time", b =>
                {
                    b.Navigation("Jogadores");

                    b.Navigation("Partidas");

                    b.Navigation("Transferencias");
                });

            modelBuilder.Entity("campeonato_brasileiro_business.Models.Torneio", b =>
                {
                    b.Navigation("Partidas");
                });
#pragma warning restore 612, 618
        }
    }
}
