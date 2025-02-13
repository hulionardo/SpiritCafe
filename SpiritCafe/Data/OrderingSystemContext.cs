using Microsoft.EntityFrameworkCore;
using SpiritCafe.Entities;

namespace SpiritCafe.Data;
public class OrderingSystemContext : DbContext
{
    public DbSet<Cook> Cooks { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<DishIngredient> DishIngredients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=SpiritCafe.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DishIngredient>()
            .HasKey(di => new { di.DishId, di.IngredientId });

        modelBuilder.Entity<OrderDetails>()
            .HasKey(od => new { od.OrderId, od.DishId });

        modelBuilder.Entity<Cook>().HasData(
            new Cook { Id = 1, Name = "Chef Gordon" },
            new Cook { Id = 2, Name = "Chef Jamie" }
            );

        modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient { Id = 1, Name = "Tomato", Price = 0.5m },
            new Ingredient { Id = 2, Name = "Cheese", Price = 1.5m },
            new Ingredient { Id = 3, Name = "Dough", Price = 2.0m }
            );

        modelBuilder.Entity<Dish>().HasData(
            new Dish { Id = 1, Name = "Pizza", Description = "Delicious cheesy pizza", EstTime = 15, Price = 4.8m }, 
            new Dish { Id = 2, Name = "Pasta", Description = "Creamy Alfredo Pasta", EstTime = 10, Price = 1.8m }
            );

        modelBuilder.Entity<DishIngredient>().HasData(
            new DishIngredient { DishId = 1, IngredientId = 1 },  
            new DishIngredient { DishId = 1, IngredientId = 2 },  
            new DishIngredient { DishId = 1, IngredientId = 3 },  
            new DishIngredient { DishId = 2, IngredientId = 2 }
            );
        }
    }
