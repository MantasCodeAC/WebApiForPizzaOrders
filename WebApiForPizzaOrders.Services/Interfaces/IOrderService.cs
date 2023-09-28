using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiForPizzaOrders.Repository.Model.DTO;
using WebApiForPizzaOrders.Repository.Model.RepositoryModels;

namespace WebApiForPizzaOrders.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseDto> AddPizza(Guid pizzaId, Guid orderId);
        Task<ResponseDto> CalculateTotalPrice(Guid orderId);
        Task<ResponseDto> DeletePizza(Pizza pizza, Guid orderId);
        Task<ResponseDto> ReviewSubmitedOrders();
        Task<ResponseDto> SubmitOrder(Order order);
        Task<ResponseDto> CreateAnOrder();
    }
}
