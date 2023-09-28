using Microsoft.EntityFrameworkCore;
using System;
using WebApiForPizzaOrders.Repository.Data;
using WebApiForPizzaOrders.Repository.Model.RepositoryModels;
using WebApiForPizzaOrders.Repository.Repositories;

namespace WebApiForPizzaOrders.Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly WebApiForPizzaOrdersDbContext _context;
        public OrderRepository(WebApiForPizzaOrdersDbContext context)
        {
            _context = context;
        }
        public async Task DeleteOrderAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Pizza> GetCreatedPizzaFromDB(Guid pizzaId)
        {
            return await _context.Pizzas.SingleOrDefaultAsync(x => x.Id == pizzaId);
        }

        public async Task<Order> GetOrderAsync(Guid orderId)
        {
            return await _context.Orders.SingleOrDefaultAsync(x => x.Id == orderId);
        }
        public async Task<List<Order>> GetOrderListAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task SaveOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
    }
}
