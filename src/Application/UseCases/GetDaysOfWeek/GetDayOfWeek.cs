using Domain.Week;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.GetDaysOfWeek
{
    public class GetDayOfWeek : IRequestHandler<GetDayOfWeekInput, GetDayOfWeekOutput>
    {
        private readonly ILogger _logger;
        private readonly IWeekRepository _weekRepository;
        public GetDayOfWeek(ILogger logger, IWeekRepository weekRepository)
        {
            _logger = logger;
            _weekRepository = weekRepository;
        }

        public async Task<GetDayOfWeekOutput> Handle(GetDayOfWeekInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting get day of week");

            if (request.DayNumber < 0 || request.DayNumber > 6)
            {
                _logger.LogError("Invalid day");
                return null;
            }

            var day = await _weekRepository.GetDayOfWeekByDayNumber(request.DayNumber);

            return new GetDayOfWeekOutput { Description = day.Description };
        }
    }
}
