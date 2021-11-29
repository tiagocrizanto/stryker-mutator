using Application.UseCases.GetDaysOfWeek;
using Domain.Week;
using FluentAssertions;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.UseCases
{
    public class GetDayOfWeekTest
    {
        private readonly DefaultFixture _fixture;

        public GetDayOfWeekTest() => _fixture = new DefaultFixture();

        [Fact(DisplayName = "ShouldReturnSuccess_WhenIsValidNumberOfDayOfWeek")]
        [Trait("GetDayOfWeek", "UnitTest")]
        public async Task ShouldReturnSuccess_WhenIsValidNumberOfDayOfWeek()
        {
            // arrange
            var input = new GetDayOfWeekInput { DayNumber = 1 };
            var output = new Day { Description = "Monday" };

            _fixture.WeekRepository
                .Setup(x => x.GetDayOfWeekByDayNumber(It.IsAny<int>()))
                .ReturnsAsync(output);

            // act
            var result = await _fixture.GetDayOfWeek.Handle(input, It.IsAny<CancellationToken>());

            // assert
            result.Should().NotBeNull();
            result.Description.Should().Be("Monday");
        }
    }
}
