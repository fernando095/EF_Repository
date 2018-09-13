﻿// <auto-generated />
using EF_New;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EF_New.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180912011045_a")]
    partial class a
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EF_New.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EstudanteId");

                    b.Property<string>("Rua");

                    b.HasKey("Id");

                    b.HasIndex("EstudanteId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("EF_New.Estudante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Idade");

                    b.Property<string>("Nome");

                    b.Property<int>("TurmaId");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.ToTable("Estudantes");
                });

            modelBuilder.Entity("EF_New.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("EF_New.Endereco", b =>
                {
                    b.HasOne("EF_New.Estudante")
                        .WithOne("Enderecos")
                        .HasForeignKey("EF_New.Endereco", "EstudanteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EF_New.Estudante", b =>
                {
                    b.HasOne("EF_New.Turma")
                        .WithMany("Estudantes")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
