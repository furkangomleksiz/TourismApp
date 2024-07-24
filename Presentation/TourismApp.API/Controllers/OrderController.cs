using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourismApp.Application.Commands;
using TourismApp.Application.Queries;

namespace TourismApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            if (command.PaxIds == null || command.PaxIds.Count == 0)
            {
                return BadRequest("At least one pax ID must be provided.");
            }

            var order = await _mediator.Send(command);
            return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var query = new GetOrderByIdQuery(id);
            var order = await _mediator.Send(query);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet("tourproduct/{tourProductId}")]
        public async Task<IActionResult> GetOrdersByTourProductId(Guid tourProductId)
        {
            var query = new GetOrdersByTourProductIdQuery(tourProductId);
            var orders = await _mediator.Send(query);

            if (orders == null || !orders.Any())
            {
                return NotFound();
            }

            return Ok(orders);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(Guid id, [FromBody] UpdateOrderStatusCommand command)
        {
            if (id != command.OrderId)
            {
                return BadRequest("Order ID mismatch.");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteOrder(Guid id)
        {
            await _mediator.Send(new SoftDeleteOrderCommand(id));
            return NoContent();
        }
    }
}