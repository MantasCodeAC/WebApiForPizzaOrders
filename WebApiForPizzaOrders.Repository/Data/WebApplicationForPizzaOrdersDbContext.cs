using Microsoft.EntityFrameworkCore;
using WebApiForPizzaOrders.Repository.Model.RepositoryModels;

namespace WebApiForPizzaOrders.Repository.Data
{
    public class WebApiForPizzaOrdersDbContext : DbContext
    {
        public WebApiForPizzaOrdersDbContext(DbContextOptions<WebApiForPizzaOrdersDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PizzaOrdersDb");
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<PizzaAndTopping> PizzaAndToppings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaAndTopping>().HasKey(x => new
            {
                x.ToppingId,
                x.PizzaId
            });
            modelBuilder.Entity<Topping>().HasMany(x => x.PizzaAndTopping).WithOne(x => x.Topping).HasForeignKey(x => x.ToppingId);
            modelBuilder.Entity<Pizza>().HasMany(x => x.PizzaAndTopping).WithOne(x => x.Pizza).HasForeignKey(x => x.PizzaId);
        }
    }
}
