﻿// <auto-generated />
using System;
using Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ContextoDados))]
    [Migration("20220323181024_addEnderecoCliente")]
    partial class addEnderecoCliente
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Domain.Entidades.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Domain.Entidades.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<long?>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<long>("IdCliente")
                        .HasColumnType("bigint");

                    b.Property<long>("Latitude")
                        .HasColumnType("bigint");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<long>("Longitude")
                        .HasColumnType("bigint");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Domain.Entidades.Leitura", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataLeitura")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("Latitude")
                        .HasColumnType("bigint");

                    b.Property<long>("LeituraAnterior")
                        .HasColumnType("bigint");

                    b.Property<long?>("LeituraAtual")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long>("LeituristaId")
                        .HasColumnType("bigint");

                    b.Property<long>("Longitude")
                        .HasColumnType("bigint");

                    b.Property<long>("OcorrenciaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("LeituristaId");

                    b.HasIndex("OcorrenciaId");

                    b.ToTable("Leitura");
                });

            modelBuilder.Entity("Domain.Entidades.Leiturista", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("Matricula")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Leituristas");
                });

            modelBuilder.Entity("Domain.Entidades.Ocorrencia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("PermiteLeitura")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Ocorrencia");
                });

            modelBuilder.Entity("Domain.Entidades.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Domain.Entidades.Endereco", b =>
                {
                    b.HasOne("Domain.Entidades.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Domain.Entidades.Leitura", b =>
                {
                    b.HasOne("Domain.Entidades.Cliente", "Cliente")
                        .WithMany("Leituras")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entidades.Leiturista", "Leiturista")
                        .WithMany("Leituras")
                        .HasForeignKey("LeituristaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entidades.Ocorrencia", "Ocorrencia")
                        .WithMany("Leituras")
                        .HasForeignKey("OcorrenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Leiturista");

                    b.Navigation("Ocorrencia");
                });

            modelBuilder.Entity("Domain.Entidades.Cliente", b =>
                {
                    b.Navigation("Leituras");
                });

            modelBuilder.Entity("Domain.Entidades.Leiturista", b =>
                {
                    b.Navigation("Leituras");
                });

            modelBuilder.Entity("Domain.Entidades.Ocorrencia", b =>
                {
                    b.Navigation("Leituras");
                });
#pragma warning restore 612, 618
        }
    }
}
