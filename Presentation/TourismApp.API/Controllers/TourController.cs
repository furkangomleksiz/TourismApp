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
    public class TourController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TourController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTours()
        {
            var query = new GetAllToursQuery();
            var tours = await _mediator.Send(query);
            return Ok(tours);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTourDetails(Guid id)
        {
            var query = new GetTourDetailsQuery(id);
            var tourDetails = await _mediator.Send(query);

            if (tourDetails == null)
            {
                return NotFound();
            }

            return Ok(tourDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTour([FromBody] CreateTourCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid tour data.");
            }

            var tourId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTourDetails), new { id = tourId }, tourId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTour(Guid id, UpdateTourCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var tourId = await _mediator.Send(command);

            if (tourId == Guid.Empty)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("{id}/gallery")]
        public async Task<IActionResult> AddToGallery(Guid id, [FromBody] string imageUrl)
        {
            // Validate inputs, authorize user, etc.

            var command = new AddToGalleryCommand { TourId = id, ImageUrl = imageUrl };
            var result = await _mediator.Send(command);

            return Ok(result);
        }

    }
}
