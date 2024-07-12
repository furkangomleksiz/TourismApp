using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Application.DTOs;
using TourismApp.Domain.Entities;

namespace TourismApp.Application.Queries
{
    public class GetAllToursQuery : IRequest<List<TourDTO>>
{
}
}