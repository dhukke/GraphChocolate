using GraphChocolate.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphChocolate.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Pizza> Pizzas { get; set; } = default!;

        public DbSet<Topping> Toppings { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Topping>()
                .HasMany(t => t.Pizzas)
                .WithOne(t => t.Topping!)
                .HasForeignKey(t => t.ToppingId);

            modelBuilder
                .Entity<Pizza>()
                .HasOne(t => t.Topping)
                .WithMany(t => t!.Pizzas)
                .HasForeignKey(t => t.ToppingId);

            modelBuilder
                .Entity<Pizza>()
                .HasData(
                    new Pizza
                    {
                        Id = 1,
                        Name = "First Pizza",
                        ToppingId = 1
                    },
                    new Pizza
                    {
                        Id = 2,
                        Name = "Second Pizza",
                        ToppingId = 1
                    },
                    new Pizza
                    {
                        Id = 3,
                        Name = "Third Pizza",
                        ToppingId = 2,
                    }
                );

            modelBuilder
                .Entity<Topping>()
                .HasData(
                    new Topping
                    {
                        Id = 1,
                        Name = "First Topping"
                    },
                    new Topping
                    {
                        Id = 2,
                        Name = "Second Topping"
                    }
                );
        }
    }
}
