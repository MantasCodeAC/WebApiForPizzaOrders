using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiForPizzaOrders.Repository.Model.DTO;
using WebApiForPizzaOrders.Repository.Model.RepositoryModels;
using WebApiForPizzaOrders.Repository.Repositories;
using WebApiForPizzaOrders.Services.Interfaces;
using WebApplicationForPizzaOrders.Repository.Repositories;

namespace WebApiForPizzaOrders.Services.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _repository;
        public PizzaService(IPizzaRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseDto> CalculatePizzaCost(Guid pizzaId)
        {
            var pizzaToCalculate = _repository.GetPizzaAsync(pizzaId);
            switch ((int)pizzaToCalculate.Result.Size)
            {
                case 0:
                    pizzaToCalculate.Result.Price = (8 + pizzaToCalculate.Result.PizzaAndTopping.Count * 0.95);
                    break;
                case 1:
                    pizzaToCalculate.Result.Price = 10 + (pizzaToCalculate.Result.PizzaAndTopping.Count * 0.95);
                    break;
                case 2:
                    pizzaToCalculate.Result.Price = 12 + pizzaToCalculate.Result.PizzaAndTopping.Count * 0.95;
                    break;
            }
            if (pizzaToCalculate.Result.PizzaAndTopping.Count > 3)
                pizzaToCalculate.Result.Price = pizzaToCalculate.Result.Price * 0.9;
            await _repository.SavePizzaAsync(await pizzaToCalculate);
            return new ResponseDto(true, $"Pizza price {pizzaToCalculate.Result.Price}");
        }

        public async Task<ResponseDto> SelectPizzaSizeAndToppings(PizzaDto pizza)
        {
                Pizza newPizaa = new Pizza()
            {
                Id = Guid.NewGuid(),
                Size = (Pizza.size)pizza.Size,
                PizzaAndTopping = new List<PizzaAndTopping>()
            };
            
            foreach (var item in pizza.Toppings)
            {
                Topping newTopping = new Topping()
                {
                    Id = Guid.NewGuid(),
                    Name = item.Name,
                };
                PizzaAndTopping newPizzaAndTopping = new PizzaAndTopping()
                {
                    PizzaId = newPizaa.Id,
                    ToppingId = newTopping.Id,
                    Pizza = newPizaa,
                    Topping = newTopping

                };
                newPizaa.PizzaAndTopping.Add(newPizzaAndTopping);
            }
            await _repository.SavePizzaAsync(newPizaa);
            return new ResponseDto(true, $"Pizza added {newPizaa.Id}");
        }
    }
}
