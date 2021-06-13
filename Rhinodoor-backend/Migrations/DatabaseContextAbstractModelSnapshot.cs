﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rhinodoor_backend.AppExtensions;

namespace Rhinodoor_backend.Migrations
{
    [DbContext(typeof(DatabaseContextAbstract))]
    partial class DatabaseContextAbstractModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.3.21201.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rhinodoor_backend.Models.Door", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DoorImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doors");
                });

            modelBuilder.Entity("Rhinodoor_backend.Models.DoorColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColorHEX")
                        .HasColumnType("int");

                    b.Property<int>("ColorRAL")
                        .HasColumnType("int");

                    b.Property<int>("DoorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoorId");

                    b.ToTable("DoorColors");
                });

            modelBuilder.Entity("Rhinodoor_backend.Models.DoorOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DoorId")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoorId");

                    b.ToTable("DoorOptions");
                });

            modelBuilder.Entity("Rhinodoor_backend.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DoorColorId")
                        .HasColumnType("int");

                    b.Property<int>("DoorId")
                        .HasColumnType("int");

                    b.Property<int>("DoorOptionId")
                        .HasColumnType("int");

                    b.Property<int>("PlacedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("PlacedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoorColorId");

                    b.HasIndex("DoorId");

                    b.HasIndex("DoorOptionId");

                    b.HasIndex("PlacedBy")
                        .IsUnique();

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Rhinodoor_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Rhinodoor_backend.Models.DoorColor", b =>
                {
                    b.HasOne("Rhinodoor_backend.Models.Door", "Door")
                        .WithMany("DoorColors")
                        .HasForeignKey("DoorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Door");
                });

            modelBuilder.Entity("Rhinodoor_backend.Models.DoorOption", b =>
                {
                    b.HasOne("Rhinodoor_backend.Models.Door", "Door")
                        .WithMany("DoorOptions")
                        .HasForeignKey("DoorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Door");
                });

            modelBuilder.Entity("Rhinodoor_backend.Models.Order", b =>
                {
                    b.HasOne("Rhinodoor_backend.Models.DoorColor", "DoorColor")
                        .WithMany("Orders")
                        .HasForeignKey("DoorColorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Rhinodoor_backend.Models.Door", "Door")
                        .WithMany("Orders")
                        .HasForeignKey("DoorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Rhinodoor_backend.Models.DoorOption", "DoorOption")
                        .WithMany("Orders")
                        .HasForeignKey("DoorOptionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Rhinodoor_backend.Models.User", "PlacedByUser")
                        .WithOne("Order")
                        .HasForeignKey("Rhinodoor_backend.Models.Order", "PlacedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Door");

                    b.Navigation("DoorColor");

                    b.Navigation("DoorOption");

                    b.Navigation("PlacedByUser");
                });

            modelBuilder.Entity("Rhinodoor_backend.Models.Door", b =>
                {
                    b.Navigation("DoorColors");

                    b.Navigation("DoorOptions");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Rhinodoor_backend.Models.DoorColor", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Rhinodoor_backend.Models.DoorOption", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Rhinodoor_backend.Models.User", b =>
                {
                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
