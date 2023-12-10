using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GreenThumb.Models
{
    public class PlantsDbContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Advice> Advice { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Server namnet här!
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumbDb;Trusted_Connection=True;");
            }
        }

        internal class PlantConfiguration : IEntityTypeConfiguration<Plant>
        {
            public void Configure(EntityTypeBuilder<Plant> builder)
            {
                
                builder.Property(p => p.Name).IsRequired();
               
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Plant>()
                .HasMany(p => p.Advices)
                .WithOne(a => a.Plant)
                .HasForeignKey(a => a.PlantId);


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plant>().HasData(

                //Lägga till nya växter 

                new Plant { Plantid = 1, Name = "Rose"},
                new Plant { Plantid = 2, Name = "Pine tree"},
                new Plant { Plantid = 3, Name = "Rosemary"},
                new Plant { Plantid = 4, Name = "Tulip"},
                new Plant { Plantid = 5, Name = "Lavender"},
                new Plant { Plantid = 6, Name = "Orchid"},
                new Plant { Plantid = 7, Name = "Sunflower"},
                new Plant { Plantid = 8, Name = "Maple"},
                new Plant { Plantid = 9, Name = "Jasmine"},
                new Plant { Plantid = 10, Name = "Lily"},
                new Plant { Plantid = 11, Name = "Cactus"},
                new Plant { Plantid = 12, Name = "Peppermint"}
                );
                

            modelBuilder.Entity<Advice>().HasData(

                //För att lägga till Advice 

                new Advice { AdviceId = 1, Description = "Place in a sunny location and water regularly to promote blooming.", PlantId = 1 },
                new Advice { AdviceId = 2, Description = "Thrives in well-drained soil and requires minimal watering; avoid overwatering.", PlantId = 2 },
                new Advice { AdviceId = 3, Description = "Water sparingly and place in a sunny location; tolerates drought and prefers warmer climates.", PlantId = 3 },
                new Advice { AdviceId = 4, Description = "Plant in well-drained soil and avoid overwatering to prevent root rot.", PlantId = 4 },
                new Advice { AdviceId = 5, Description = "Place in a sunny location, water sparingly, and trim back flowers to encourage growth.", PlantId = 5 },
                new Advice { AdviceId = 6, Description = "Water moderately, avoid overwatering; place in indirect light and provide support for upright growth.", PlantId = 6 },
                new Advice { AdviceId = 7, Description = "Plant in a sunny location, provide support to prevent toppling, and water regularly.", PlantId = 7 },
                new Advice { AdviceId = 8, Description = "Thrives in moist, well-drained soil; avoid waterlogging and provide protection in extreme weather.", PlantId = 8 },
                new Advice { AdviceId = 9, Description = "Plant in well-drained soil, provide support for climbing varieties, and water consistently.", PlantId = 9 },
                new Advice { AdviceId = 10, Description = "Plant in well-drained soil, water regularly, and provide support for taller varieties.", PlantId = 10 },
                new Advice { AdviceId = 11, Description = "Use well-draining soil, water sparingly, and place in a sunny location; avoid overwatering.", PlantId = 11 },
                new Advice { AdviceId = 12, Description = "Plant in partial shade, keep soil consistently moist, and prune regularly to encourage bushy growth.", PlantId = 12 }

                );

        }
    }
}


