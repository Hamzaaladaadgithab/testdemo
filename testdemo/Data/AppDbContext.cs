using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testdemo.Models;


// Eğer Item.cs başka klasördeyse bunu eklemelisin

namespace testdemo.Data  // Proje adınla uyumlu olmalı
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
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

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1c7a2b3f-1234-4567-89ab-1234567890ab",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "2a8b9c4d-2345-5678-90cd-2345678901bc"
                },
                new IdentityRole
                {
                    Id = "3d8e4f5a-3456-6789-01de-3456789012cd",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "4e9f5a6b-4567-7890-12ef-2345678901de"
                }
            );




            base.OnModelCreating(modelBuilder);
        }
    }
}

