﻿using Microsoft.EntityFrameworkCore;
using ShoppingGames.Data.Entities;
// This package it need to be installer to use

namespace ShoppingGames.Data
{
    public class DataContext: DbContext
    {
        //options it can be whatever name
        //Form to conect to Database
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        }
    }
}