using WebApiForPizzaOrders.Repository.Model.RepositoryModels;

namespace WebApiForPizzaOrders.Repository.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderAsync(Guid orderId);
        Task<List<Order>> GetOrderListAsync();
        Task SaveOrderAsync(Order order);
        Task DeleteOrderAsync(Order order);
        Task<Pizza> GetCreatedPizzaFromDB(Guid pizzaId);
    }
}
