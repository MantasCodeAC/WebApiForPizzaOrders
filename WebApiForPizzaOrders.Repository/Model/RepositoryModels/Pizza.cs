using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiForPizzaOrders.Repository.Model.RepositoryModels
{
    public class Pizza
    {
        public Guid Id { get; set; }
        public size Size { get; set; }
        public List<PizzaAndTopping> PizzaAndTopping { get; set; }
        public double Price { get; set; }
        public enum size
        {
            Small = 0,
            Medium = 1,
            Large = 2
        }
        public Guid OrderId { get; set; }
    }
}
