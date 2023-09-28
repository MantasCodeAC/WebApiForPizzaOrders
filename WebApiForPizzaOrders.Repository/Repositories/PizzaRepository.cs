using Microsoft.EntityFrameworkCore;
using WebApiForPizzaOrders.Repository.Data;
using WebApiForPizzaOrders.Repository.Model.RepositoryModels;

namespace WebApplicationForPizzaOrders.Repository.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly WebApiForPizzaOrdersDbContext _context;
        public PizzaRepository(WebApiForPizzaOrdersDbContext context)
        {
            _context = context;
        }

        public async Task DeletePizzaAsync(Pizza pizza)
        {
            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();
        }

        public async Task<Pizza> GetPizzaAsync(Guid pizzaId)
        {
            return await _context.Pizzas.SingleOrDefaultAsync(x => x.Id == pizzaId);
        }

        public async Task SavePizzaAsync(Pizza pizza)
        {
            await _context.Pizzas.AddAsync(pizza);
            await _context.SaveChangesAsync();
        }
    }
}
