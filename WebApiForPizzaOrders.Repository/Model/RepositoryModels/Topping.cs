using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiForPizzaOrders.Repository.Model.RepositoryModels
{
    public class Topping
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<PizzaAndTopping> PizzaAndTopping { get; set; }
    }
}
