using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TourismApp.Domain.Entities;

namespace TourismApp.Application.Commands
{
    public class CreateTourCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public string GeneralInfo { get; set; }
    public string SlugUrl { get; set; }
    public string Image { get; set; }
    public int DayNum { get; set; }
    public int NightNum { get; set; }
    public List<TourImage> Gallery { get; set; }
    public bool IsActive { get; set; }
}

}