using Microsoft.EntityFrameworkCore;
using testdemo.Models;  // Eğer Item.cs başka klasördeyse bunu eklemelisin

namespace testdemo.Data  // Proje adınla uyumlu olmalı
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        public DbSet<Item> Items { get; set; }
    }
}
