using Microsoft.EntityFrameworkCore;

namespace WebShop.Models
{
    

    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<FileDB> Files { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
           // Database.EnsureDeleted();
            Database.EnsureCreated();   // создаем БД
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            
            var product = new Product
            {
                ProductId = 1,
                Availability = AvailabilityType.InStock,
                Name = "Smartphone",
                Category = CategoryType.Smartphone,
                Count = 30,
                Description = "Smartphone Description",
                Price = 900,

            };
            modelBuilder.Entity<Product>().HasData(
                product);

            modelBuilder.Entity<FileDB>().HasData(
                new FileDB
                {
                    Id = 1,
                    ProductId = 1,
                    Name = "product_1.jpg",
                    Path = "/images/product_1.jpg"
                    

                },
                new FileDB
                {
                    Id = 2,
                    ProductId = 1,
                    Name = "product_1.jpg",
                    Path = "/images/product_1.jpg"

                },
                new FileDB
                {
                    Id = 3,
                    ProductId = 1,
                    Name = "product_1.jpg",
                    Path = "/images/product_1.jpg"

                },
                new FileDB
                {
                    Id = 4,
                    ProductId = 1,
                    Name = "product_1.jpg",
                    Path = "/images/product_1.jpg"

                });

        }
    }
}
