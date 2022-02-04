﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RobotsData;

#nullable disable

namespace RobotsData.Migrations
{
    [DbContext(typeof(RobotsContext))]
    partial class RobotsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RobotsData.Models.Grid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("XSize")
                        .HasColumnType("int");

                    b.Property<int>("YSize")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Grids");
                });

            modelBuilder.Entity("RobotsData.Models.Robot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GridId")
                        .HasColumnType("int");

                    b.Property<bool>("IsLost")
                        .HasColumnType("bit");

                    b.Property<int>("Orientation")
                        .HasColumnType("int");

                    b.Property<int>("XPosition")
                        .HasColumnType("int");

                    b.Property<int>("YPosition")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GridId");

                    b.ToTable("Robots");
                });

            modelBuilder.Entity("RobotsData.Models.Robot", b =>
                {
                    b.HasOne("RobotsData.Models.Grid", "Grid")
                        .WithMany("Robots")
                        .HasForeignKey("GridId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grid");
                });

            modelBuilder.Entity("RobotsData.Models.Grid", b =>
                {
                    b.Navigation("Robots");
                });
#pragma warning restore 612, 618
        }
    }
}
