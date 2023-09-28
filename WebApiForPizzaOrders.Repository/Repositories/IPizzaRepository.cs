using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiForPizzaOrders.Repository.Model.RepositoryModels;

namespace WebApplicationForPizzaOrders.Repository.Repositories
{
    public interface IPizzaRepository
    {
        Task<Pizza> GetPizzaAsync(Guid pizzaId);
        Task SavePizzaAsync(Pizza pizza);
        Task DeletePizzaAsync(Pizza pizza);
    }
}
