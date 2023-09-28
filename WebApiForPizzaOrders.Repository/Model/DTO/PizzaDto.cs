using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiForPizzaOrders.Repository.Model.RepositoryModels;

namespace WebApiForPizzaOrders.Repository.Model.DTO
{
    public class PizzaDto
    {
        public size Size { get; set; }
        public List<ToppingDto> Toppings { get; set; }
        public enum size
        {
            Small = 0,
            Medium = 1,
            Large = 2
        }
    }
}
