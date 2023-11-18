﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RandomGenerate.Models;

#nullable disable

namespace RandomGenerate.Migrations
{
    [DbContext(typeof(WordDbContext))]
    [Migration("20230131142513_initial create")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RandomGenerate.Models.Word", b =>
                {
                    b.Property<int>("VocableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VocableId"), 1L, 1);

                    b.Property<string>("Counter")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Vocable")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("VocableId");

                    b.ToTable("Words");
                });
#pragma warning restore 612, 618
        }
    }
}
