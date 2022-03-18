using Microsoft.EntityFrameworkCore;
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

        internal Task CheckCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(cat => cat.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique();
            modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique();
        }
    }
}
