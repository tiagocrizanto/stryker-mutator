using MediatR;
using System.Collections.Generic;

namespace Application.UseCases.GetDays
{
    public class GetDaysInput : IRequest<List<string>>
    {
        public int DayNumber { get; set; }
    }
}
