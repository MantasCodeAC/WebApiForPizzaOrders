using Microsoft.AspNetCore.Mvc;
using WebApiForPizzaOrders.Repository.Model.DTO;
using WebApiForPizzaOrders.Repository.Model.RepositoryModels;
using WebApiForPizzaOrders.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiForPizzaOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: api/<OrderController>
        [HttpGet("Get Order List")]

        public async Task<ActionResult<ResponseDto>> GetOrderList()
        {
            var response = await _orderService.ReviewSubmitedOrders();
            if (!response.IsSuccess)
                return BadRequest();
            return Ok(response.Message);
        }

        // POST api/<OrderController>
        [HttpPost("Create Order")]
        public async Task<ActionResult> CreateOrder()
        {
            var response = await _orderService.CreateAnOrder();
            if (!response.IsSuccess)
                return BadRequest();
            return Ok(response.Message);
        }

        // POST api/<OrderController>
        [HttpPut("Add Pizza To Order")]
        public async Task<ActionResult> AddPizzaToOrder([FromQuery] Guid pizzaId, Guid orderId)
        {
            var response = await _orderService.AddPizza(pizzaId, orderId);
            if (!response.IsSuccess)
                return BadRequest();
            return Ok(response.Message);
        }
    }
}
