using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiForPizzaOrders.Repository.Model.RepositoryModels
{
    public class PizzaAndTopping
    {
        public Guid PizzaId { get; set; }
        public Guid ToppingId { get; set; }
        public Pizza Pizza { get; set; }
        public Topping Topping { get; set; }
    }
}
