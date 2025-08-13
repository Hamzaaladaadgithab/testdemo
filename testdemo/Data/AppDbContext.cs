using Microsoft.EntityFrameworkCore;
using testdemo.Models;  


// Eğer Item.cs başka klasördeyse bunu eklemelisin

namespace testdemo.Data  // Proje adınla uyumlu olmalı
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        public DbSet<Item> Items { get; set; }
        // Eğer Category.cs başka bir klasördeyse, o klasörü de eklemelisin 
        // ve bu DbSet'i de eklemelisin
        // Eğer Category.cs aynı klasördeyse, bu satırı değiştirmene gerek yok
        
        public DbSet<Category> Categorys { get; set; }

     

        public DbSet<Employee> Employees { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Correct usage: call Entity<Category>() and then HasData on the returned EntityTypeBuilder<Category>
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Select Category" },
                new Category() { Id = 2, Name = "Comuters" },
                new Category() { Id = 3, Name = "Mobiles" },
                new Category() { Id = 4, Name = "Electric machines" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
