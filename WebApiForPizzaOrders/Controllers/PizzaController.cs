using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiForPizzaOrders.Repository.Model.DTO;
using WebApiForPizzaOrders.Services.Interfaces;

namespace WebApiForPizzaOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzzaService;
        public PizzaController(IPizzaService pizzzaService)
        {
            _pizzzaService = pizzzaService;
        }
        // POST api/<PizzaController>
        [HttpPost("Create Pizza")]
        public async Task<ActionResult> CreatePizza([FromBody] PizzaDto pizza)
        {
            var response = await _pizzzaService.SelectPizzaSizeAndToppings(pizza);
            if (!response.IsSuccess)
                return BadRequest();
            return Ok(response.Message);
        }
        [HttpPut("Calculate Pizza Price")]
        public async Task<ActionResult> CalculateThePrice([FromBody] Guid pizzaId)
        {
            var response = await _pizzzaService.CalculatePizzaCost(pizzaId);
            if (!response.IsSuccess)
                return BadRequest();
            return Ok(response.Message);
        }
    }
}
