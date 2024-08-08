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
    public class PaxController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaxController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePax([FromBody] CreatePaxCommand command)
        {
            var paxId = await _mediator.Send(command);
            return Ok(paxId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePax(Guid id, [FromBody] UpdatePaxCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Pax ID in the URL does not match Pax ID in the request body.");
            }

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound("Pax not found.");
            }

            return NoContent();
        }
    }
}