using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourismApp.Application.Commands;
using TourismApp.Application.Queries;

namespace TourismApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TourProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTourProducts()
        {
            var query = new GetAllTourProductsQuery();
            var tourProducts = await _mediator.Send(query);
            return Ok(tourProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTourProductDetails(Guid id)
        {
            var query = new GetTourProductDetailsQuery(id);
            var tourProductDetails = await _mediator.Send(query);

            if (tourProductDetails == null)
            {
                return NotFound();
            }

            return Ok(tourProductDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTourProduct([FromBody] CreateTourProductCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid tour product data.");
            }

            var tourProductId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTourProductDetails), new { id = tourProductId }, tourProductId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTourProduct(Guid id, UpdateTourProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var tourProductId = await _mediator.Send(command);

            if (tourProductId == Guid.Empty)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
