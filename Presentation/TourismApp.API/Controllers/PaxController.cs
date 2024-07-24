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
    }
}