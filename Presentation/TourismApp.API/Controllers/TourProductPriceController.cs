using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TourismApp.Application.Commands;
using TourismApp.Application.Queries;
using TourismApp.Domain.Entities;

namespace TourismApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourProductPriceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TourProductPriceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/TourProductPrice
        [HttpPost]
        public async Task<IActionResult> CreateTourProductPrice([FromBody] CreateTourProductPriceCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTourProductPriceById), new { id }, command);
        }

        // PUT: api/TourProductPrice/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTourProductPrice(Guid id, [FromBody] UpdateTourProductPriceCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // GET: api/TourProductPrice/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTourProductPriceById(Guid id)
        {
            var query = new GetTourProductPriceByIdQuery(id);
            var tourProductPrice = await _mediator.Send(query);
            if (tourProductPrice == null)
            {
                return NotFound();
            }

            return Ok(tourProductPrice);
        }

        // GET: api/TourProductPrice/byType
        [HttpGet("byType")]
        public async Task<IActionResult> GetTourProductPriceByType([FromQuery] Guid tourProductId, [FromQuery] PriceType priceType)
        {
            var query = new GetTourProductPricesByTypeQuery(tourProductId, priceType);
            var tourProductPrice = await _mediator.Send(query);
            if (tourProductPrice == null)
            {
                return NotFound();
            }

            return Ok(tourProductPrice);
        }
    }

}