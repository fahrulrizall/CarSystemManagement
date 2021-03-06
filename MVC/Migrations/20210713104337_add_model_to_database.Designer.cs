// <auto-generated />
using System;
using MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVC.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20210713104337_add_model_to_database")]
    partial class add_model_to_database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVC.Models.CarDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Brought")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Owner")
                        .HasColumnType("int");

                    b.Property<int>("Id_Services")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_Owner");

                    b.HasIndex("Id_Services");

                    b.ToTable("CarDetails");
                });

            modelBuilder.Entity("MVC.Models.CarOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarOwner");
                });

            modelBuilder.Entity("MVC.Models.CarServices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Id_Mechanics")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status_Proposal")
                        .HasColumnType("bit");

                    b.Property<bool>("Status_Proses")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Id_Mechanics");

                    b.ToTable("CarServices");
                });

            modelBuilder.Entity("MVC.Models.Mechanics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mechanics");
                });

            modelBuilder.Entity("MVC.Models.CarDetails", b =>
                {
                    b.HasOne("MVC.Models.CarOwner", "CarOwner")
                        .WithMany()
                        .HasForeignKey("Id_Owner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC.Models.CarServices", "CarServices")
                        .WithMany()
                        .HasForeignKey("Id_Services")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarOwner");

                    b.Navigation("CarServices");
                });

            modelBuilder.Entity("MVC.Models.CarServices", b =>
                {
                    b.HasOne("MVC.Models.Mechanics", "Mechanics")
                        .WithMany()
                        .HasForeignKey("Id_Mechanics")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mechanics");
                });
#pragma warning restore 612, 618
        }
    }
}
