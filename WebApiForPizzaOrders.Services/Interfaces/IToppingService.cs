using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiForPizzaOrders.Services.Interfaces
{
    public interface IToppingService
    {
        Task AddTopping();
        Task DeleteTopping();
    }
}
