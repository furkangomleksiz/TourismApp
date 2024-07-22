using MediatR;
using System;

namespace TourismApp.Application.Commands
{
    public class DeleteTourProductCommand : IRequest
    {
        public Guid Id { get; }

        public DeleteTourProductCommand(Guid id)
        {
            Id = id;
        }
    }
}