using Application.UseCases.GetDays;
using Application.UseCases.GetDaysOfWeek;
using Domain.Week;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.AutoMock;
using WebApi.Controllers;

namespace UnitTests
{
    public class DefaultFixture
    {
        public DefaultFixture()
        {
            var mocker = new AutoMocker();
            Mediator = mocker.GetMock<IMediator>();

            WeekRepository = mocker.GetMock<IWeekRepository>();
            GetDayOfWeekLogger = mocker.GetMock<ILogger<GetDayOfWeek>>();
            GetDayOfWeek = new GetDayOfWeek(GetDayOfWeekLogger.Object, WeekRepository.Object);

            HomeController = new HomeController(Mediator.Object);
        }

        public Mock<IMediator> Mediator { get; }

        public Mock<IWeekRepository> WeekRepository;

        public GetDays GetDay { get; }
        public GetDayOfWeek GetDayOfWeek { get; }
        public Mock<ILogger<GetDayOfWeek>> GetDayOfWeekLogger { get; }

        public HomeController HomeController { get; }
    }
}
