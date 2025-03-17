using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {

        private readonly GetOrderDetailQueryHandler _orderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _orderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

        public OrderDetailsController(RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, GetOrderDetailByIdQueryHandler orderDetailByIdQueryHandler, GetOrderDetailQueryHandler orderDetailQueryHandler)
        {
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _orderDetailByIdQueryHandler = orderDetailByIdQueryHandler;
            _orderDetailQueryHandler = orderDetailQueryHandler;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("The Order Details Had Been Deleted Successfully");
        }
        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _orderDetailQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetailById(int id)
        {
            var value = await _orderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("The Order Detail Had Been Created Successfully");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);
            return Ok("The Order Detail Had Been Updated Successfully");
        }
    }
}
