using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiForPizzaOrders.Repository.Model.DTO;
using WebApiForPizzaOrders.Repository.Model.RepositoryModels;
using WebApiForPizzaOrders.Repository.Repositories;
using WebApiForPizzaOrders.Services.Interfaces;

namespace WebApiForPizzaOrders.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseDto> AddPizza(Guid pizzaId, Guid orderId)
        {
            var currentOrder = await _repository.GetOrderAsync(orderId);
            currentOrder.Pizzas.Add(_repository.GetCreatedPizzaFromDB(pizzaId).Result);
            await _repository.SaveOrderAsync(currentOrder);
            return new ResponseDto(true, $"Pizza added");
        }

        public async Task<ResponseDto> CalculateTotalPrice(Guid orderId)
        {
            var currentOrder = await _repository.GetOrderAsync(orderId);
            currentOrder.TotalPrice = currentOrder.Pizzas.Sum(x => x.Price);
            await _repository.SaveOrderAsync(currentOrder);
            return new ResponseDto(true, $"Total price {currentOrder.TotalPrice}");
        }

        public async Task<ResponseDto> DeletePizza(Pizza pizza, Guid orderId)
        {
            var currentOrder = await _repository.GetOrderAsync(orderId);
            currentOrder.Pizzas.Remove(pizza);
            await _repository.SaveOrderAsync(currentOrder);
            return new ResponseDto(true, $"Pizza {pizza.Id} deleted");
        }

        public async Task<ResponseDto> ReviewSubmitedOrders()
        {
            var orders = await _repository.GetOrderListAsync();
            return new ResponseDto(true, $"Number of orders in a list: {orders.Count}");
        }

        public async Task<ResponseDto> SubmitOrder(Order order)
        {
            await _repository.SaveOrderAsync(order);
            return new ResponseDto(true, $"Order submited. Order Id: {order}");
        }
        public async Task <ResponseDto> CreateAnOrder()
        {
            Order order = new Order
            {
                Id = Guid.NewGuid()
            };
            await _repository.SaveOrderAsync(order);
            return new ResponseDto(true, $"New order created. Order Id: {order.Id}");
        }
    }
}
