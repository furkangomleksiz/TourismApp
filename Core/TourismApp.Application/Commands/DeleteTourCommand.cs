using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace TourismApp.Application.Commands
{
    public class DeleteTourCommand : IRequest
{
    public Guid Id { get; set; }

    public DeleteTourCommand(Guid id)
    {
        Id = id;
    }
}
}