using Domain.Week;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.GetDays
{
    public class GetDays : IRequestHandler<GetDaysInput, List<string>>
    {
        private readonly IWeekRepository _weekRepository;
        public GetDays(IWeekRepository weekRepository)
        {
            _weekRepository = weekRepository;
        }

        public async Task<List<string>> Handle(GetDaysInput request, CancellationToken cancellationToken)
        {
            return (await _weekRepository.GetDaysOfWeek()).Select(d => d.Description).ToList();
        }
    }
}
