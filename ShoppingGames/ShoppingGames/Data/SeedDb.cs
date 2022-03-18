using ShoppingGames.Data.Entities;

namespace ShoppingGames.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context; 
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await  CheckCategoriesAsync();
            await CheckCountriesAsync();
        }

        private async Task CheckCountriesAsync()
        {
            if(!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State { 
                            Name = "Antioquia",
                            Cities = new List<City>()
                            {
                                new City { Name = "Medellin"},
                                new City { Name = "Envigado"},
                                new City { Name = "Itagui"},
                                new City { Name = "La Estrella"},
                                new City { Name = "Sabaneta"},

                            }
                          
                        },
                    }
                });
            }
        }

        private async Task CheckCategoriesAsync()
        {
            if(!_context.categories.Any())
            {
                _context.categories.Add(new Category { Name = "Tecnología" });
                _context.categories.Add(new Category { Name = "Ropa" });
                _context.categories.Add(new Category { Name = "Calzado" });
                _context.categories.Add(new Category { Name = "Belleza" });
                _context.categories.Add(new Category { Name = "Nutrición" });
                _context.categories.Add(new Category { Name = "Deportes" });
                _context.categories.Add(new Category { Name = "Apple" });
                _context.categories.Add(new Category { Name = "Mascotas" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
