﻿// <auto-generated />
using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenThumb.Migrations
{
    [DbContext(typeof(PlantsDbContext))]
    [Migration("20231206133849_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GreenThumb.Models.Advice", b =>
                {
                    b.Property<int>("AdviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdviceId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.HasKey("AdviceId");

                    b.HasIndex("PlantId");

                    b.ToTable("Advice");

                    b.HasData(
                        new
                        {
                            AdviceId = 1,
                            Description = "Place in a sunny location and water regularly to promote blooming.",
                            PlantId = 1
                        },
                        new
                        {
                            AdviceId = 2,
                            Description = "Thrives in well-drained soil and requires minimal watering; avoid overwatering.",
                            PlantId = 2
                        },
                        new
                        {
                            AdviceId = 3,
                            Description = "Water sparingly and place in a sunny location; tolerates drought and prefers warmer climates.",
                            PlantId = 3
                        },
                        new
                        {
                            AdviceId = 4,
                            Description = "Plant in well-drained soil and avoid overwatering to prevent root rot.",
                            PlantId = 4
                        },
                        new
                        {
                            AdviceId = 5,
                            Description = "Place in a sunny location, water sparingly, and trim back flowers to encourage growth.",
                            PlantId = 5
                        },
                        new
                        {
                            AdviceId = 6,
                            Description = "Water moderately, avoid overwatering; place in indirect light and provide support for upright growth.",
                            PlantId = 6
                        },
                        new
                        {
                            AdviceId = 7,
                            Description = "Plant in a sunny location, provide support to prevent toppling, and water regularly.",
                            PlantId = 7
                        },
                        new
                        {
                            AdviceId = 8,
                            Description = "Thrives in moist, well-drained soil; avoid waterlogging and provide protection in extreme weather.",
                            PlantId = 8
                        },
                        new
                        {
                            AdviceId = 9,
                            Description = "Plant in well-drained soil, provide support for climbing varieties, and water consistently.",
                            PlantId = 9
                        },
                        new
                        {
                            AdviceId = 10,
                            Description = "Plant in well-drained soil, water regularly, and provide support for taller varieties.",
                            PlantId = 10
                        },
                        new
                        {
                            AdviceId = 11,
                            Description = "Use well-draining soil, water sparingly, and place in a sunny location; avoid overwatering.",
                            PlantId = 11
                        },
                        new
                        {
                            AdviceId = 12,
                            Description = "Plant in partial shade, keep soil consistently moist, and prune regularly to encourage bushy growth.",
                            PlantId = 12
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.Plant", b =>
                {
                    b.Property<int>("Plantid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Plantid"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Plantid");

                    b.ToTable("Plants");

                    b.HasData(
                        new
                        {
                            Plantid = 1,
                            Name = "Rose"
                        },
                        new
                        {
                            Plantid = 2,
                            Name = "Pine tree"
                        },
                        new
                        {
                            Plantid = 3,
                            Name = "Rosemary"
                        },
                        new
                        {
                            Plantid = 4,
                            Name = "Tulip"
                        },
                        new
                        {
                            Plantid = 5,
                            Name = "Lavender"
                        },
                        new
                        {
                            Plantid = 6,
                            Name = "Orchid"
                        },
                        new
                        {
                            Plantid = 7,
                            Name = "Sunflower"
                        },
                        new
                        {
                            Plantid = 8,
                            Name = "Maple"
                        },
                        new
                        {
                            Plantid = 9,
                            Name = "Jasmine"
                        },
                        new
                        {
                            Plantid = 10,
                            Name = "Lily"
                        },
                        new
                        {
                            Plantid = 11,
                            Name = "Cactus"
                        },
                        new
                        {
                            Plantid = 12,
                            Name = "Peppermint"
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.Advice", b =>
                {
                    b.HasOne("GreenThumb.Models.Plant", "Plant")
                        .WithMany("Advices")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GreenThumb.Models.Plant", b =>
                {
                    b.Navigation("Advices");
                });
#pragma warning restore 612, 618
        }
    }
}
