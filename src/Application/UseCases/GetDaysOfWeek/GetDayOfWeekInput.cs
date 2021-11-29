using MediatR;

namespace Application.UseCases.GetDaysOfWeek
{
    public class GetDayOfWeekInput : IRequest<GetDayOfWeekOutput>
    {
        public int DayNumber { get; set; }
    }
}
