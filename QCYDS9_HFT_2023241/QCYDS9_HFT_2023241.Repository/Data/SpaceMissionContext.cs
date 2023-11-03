using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using QCYDS9_HFT_2023241.Models;

namespace QCYDS9_HFT_2023241.Repository
{
    public class SpaceMissionContext : DbContext
    {
        public DbSet<Astronaut> Astronauts { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Spaceship> Spacehips { get; set; }

        public SpaceMissionContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseInMemoryDatabase("missiondb")
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spaceship>(s =>
            s.HasMany(x => x.Missions)
            .WithOne(x => x.Spaceship)
                .OnDelete(DeleteBehavior.NoAction));

            modelBuilder.Entity<Mission>(m =>
            m.HasOne(x => x.Spaceship)
                .WithMany(x => x.Missions)
                .HasForeignKey(x => x.SpaceshipId)
                .OnDelete(DeleteBehavior.NoAction));

            modelBuilder.Entity<Mission>(m =>
            m.HasMany(x => x.Astronauts)
                .WithOne(x => x.Mission)
                .OnDelete(DeleteBehavior.NoAction));

            modelBuilder.Entity<Astronaut>(m =>
            m.HasOne(x => x.Mission)
                .WithMany(x => x.Astronauts)
                .HasForeignKey(x => x.MissionId)
                .OnDelete(DeleteBehavior.NoAction));



            modelBuilder.Entity<Spaceship>().HasData(new Spaceship[]
            {
               new Spaceship(1, "Apollo 11", 39937, 1969),
                new Spaceship(2, "Voyager 1", 61409, 1977),
                new Spaceship(7, "Space Shuttle Discovery", 27650, 1983),
                new Spaceship(4, "New Horizons", 16260, 2006),
                new Spaceship(5, "Juno", 22265, 2011),
                new Spaceship(6, "Perseverance Rover", 9995, 2020) });

            modelBuilder.Entity<Astronaut>().HasData(new Astronaut[]
            {   new Astronaut(1, 3, "Jeffrey Williams", "USA", 1958,true),
                new Astronaut(2, 1, "Aleksey Ovchinin", "RUS", 1971,true),
                
                new Astronaut(4, 4, "Ernst Messerschmid", "GER", 1945, true),
                new Astronaut(5, 1, "Wubbo Ockels", "NED", 1946, true),
                new Astronaut(6, 6, "Amanda Gibson", "USA", 1936, false),
                new Astronaut(7, 2, "William Pogue", "USA", 1930, true),
                new Astronaut(8, 4, "Gerald P. Carr", "USA", 1932, true),
                new Astronaut(9, 2, "Frank De Winne", "BEL", 1961, true),
                new Astronaut(10,1, "John 'Jack' Swigert", "USA", 1931, true),
                new Astronaut(11, 4, "Paula Lovell", "USA", 1928, false)
            });

            //var missions = new List<Mission>()
            modelBuilder.Entity<Mission>().HasData(new Mission[]
            {
                new Mission(1, 2, "Apollo 11", 355000, "Lunar Landing", 1969),
                new Mission(2, 3, "Mars Science Laboratory (Curiosity Rover)", 2500, "Mars Surface Exploration", 2011),
                new Mission(3, 3, "Hubble Space Telescope", 2500, "Astronomical Observations", 1990),
                new Mission(4, 1, "Voyager 1", 865, "Interstellar Space Exploration", 1977),
                new Mission(5, 1, "Mars Rover 2020 (Perseverance Rover)", 2700, "Mars Surface Exploration", 2020),
                new Mission(6, 2, "New Horizons", 720, "Pluto Exploration", 2006)

            });
            //modelBuilder.Entity<Spaceship>().HasData(spacehips);
            //modelBuilder.Entity<Astronaut>().HasData(astronauts);
            //modelBuilder.Entity<Mission>().HasData(missions);

        }
    }
}

