﻿// <auto-generated />
using System;
using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Linha", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Linhas");
                });

            modelBuilder.Entity("Core.Entities.Parada", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("LinhaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("LinhaId");

                    b.ToTable("Paradas");
                });

            modelBuilder.Entity("Core.Entities.Veiculo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("LinhaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("LinhaId");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("Core.Entities.Parada", b =>
                {
                    b.HasOne("Core.Entities.Linha", null)
                        .WithMany("Paradas")
                        .HasForeignKey("LinhaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("Core.ValueObjects.Localizacao", "Localizacao", b1 =>
                        {
                            b1.Property<long>("ParadaId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<double>("Latitude")
                                .HasColumnType("float")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float")
                                .HasColumnName("Longitude");

                            b1.HasKey("ParadaId");

                            b1.ToTable("Paradas");

                            b1.WithOwner()
                                .HasForeignKey("ParadaId");
                        });

                    b.Navigation("Localizacao");
                });

            modelBuilder.Entity("Core.Entities.Veiculo", b =>
                {
                    b.HasOne("Core.Entities.Linha", "Linha")
                        .WithMany("Veiculos")
                        .HasForeignKey("LinhaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("Core.ValueObjects.Localizacao", "Localizacao", b1 =>
                        {
                            b1.Property<long>("VeiculoId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<double>("Latitude")
                                .HasColumnType("float")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float")
                                .HasColumnName("Longitude");

                            b1.HasKey("VeiculoId");

                            b1.ToTable("Veiculos");

                            b1.WithOwner()
                                .HasForeignKey("VeiculoId");
                        });

                    b.Navigation("Linha");

                    b.Navigation("Localizacao");
                });

            modelBuilder.Entity("Core.Entities.Linha", b =>
                {
                    b.Navigation("Paradas");

                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
