﻿using Covauto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Covauto.Domain.Data
{
    public class Boeken2025Context : DbContext
    {
        public Boeken2025Context(DbContextOptions<Boeken2025Context> options) : base(options) { }

        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Auto> Autos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Gebruiker>().HasData(new Gebruiker { Id = 1, Naam = "Mark J. Prijs" });
            modelBuilder.Entity<Gebruiker>().HasData(new Gebruiker { Id = 2, Naam = "Joseph Albahari" });
            modelBuilder.Entity<Auto>().HasData(new Auto
            {
                Id = 1,
                GebruikerId = 1,
                naamAuto = "BMW",
                kilometerstand = 2023,
                startAdres = "Koeweide",
                eindAdres = "alweer koeweide",
                beschikbaarheid = true,
            });
            modelBuilder.Entity<Auto>().HasData(new Auto
            {
                Id = 2,
                GebruikerId = 2,
                naamAuto = "BMW2",
                kilometerstand = 2022223,
                startAdres = "Schaapweide",
                eindAdres = "alweer Schaapweide",
                beschikbaarheid = true,
            });
        }
    }
}