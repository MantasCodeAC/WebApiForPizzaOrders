using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiForPizzaOrders.Repository.Model.RepositoryModels
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public double TotalPrice { get; set; }
    }
}
