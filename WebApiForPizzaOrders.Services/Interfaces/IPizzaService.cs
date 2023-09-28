using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiForPizzaOrders.Repository.Model.DTO;

namespace WebApiForPizzaOrders.Services.Interfaces
{
    public interface IPizzaService
    {
        Task<ResponseDto> SelectPizzaSizeAndToppings(PizzaDto pizza);
        Task<ResponseDto> CalculatePizzaCost(Guid pizzaId);
    }
}
