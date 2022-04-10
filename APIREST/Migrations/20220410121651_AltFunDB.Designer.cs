﻿// <auto-generated />
using System;
using APIREST.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIREST.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220410121651_AltFunDB")]
    partial class AltFunDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIREST.Models.Atendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAgenda")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataAtendimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAtendente")
                        .HasColumnType("int");

                    b.Property<int>("IdMedico")
                        .HasColumnType("int");

                    b.Property<int>("IdPacienteAtendido")
                        .HasColumnType("int");

                    b.Property<int>("IdProcedimentoMedico")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Atendimentos");
                });

            modelBuilder.Entity("APIREST.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pessoa");
                });

            modelBuilder.Entity("APIREST.Models.Procedimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Procedimentos");
                });

            modelBuilder.Entity("APIREST.Models.Funcionario", b =>
                {
                    b.HasBaseType("APIREST.Models.Pessoa");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("matricula")
                        .HasColumnType("int");

                    b.Property<string>("profissao")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Funcionario");
                });

            modelBuilder.Entity("APIREST.Models.Paciente", b =>
                {
                    b.HasBaseType("APIREST.Models.Pessoa");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prontoario")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}
