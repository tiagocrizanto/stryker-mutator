using Application.UseCases.GetDaysOfWeek;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Controllers
{
    public class HomeControllerTest
    {
        private readonly DefaultFixture _fixture;
        public HomeControllerTest() => _fixture = new DefaultFixture();

        [Fact(DisplayName = "ShouldReturnSuccess_WhenIsValidDayOfWeek")]
        [Trait("OrderController", "UnitTest")]
        public async Task ShouldReturnSuccess_WhenIsValidDayOfWeek()
        {
            // arrange
            var output = new GetDayOfWeekOutput { Description = "sunday" };
            _fixture.Mediator
                .Setup(m => m.Send(It.IsAny<GetDayOfWeekInput>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(output);

            // act
            var result = await _fixture.HomeController.GetDayOfWeekName(It.IsAny<int>()) as ObjectResult;

            // assert
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "ShouldReturnBadRequest_WhenIsInvalidDayOfWeek")]
        [Trait("OrderController", "UnitTest")]
        public async Task ShouldReturnBadRequest_WhenIsInvalidDayOfWeek()
        {
            // arrange
            _fixture.Mediator
                .Setup(m => m.Send(It.IsAny<GetDayOfWeekInput>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((GetDayOfWeekOutput) null);

            // act
            var result = await _fixture.HomeController.GetDayOfWeekName(It.IsAny<int>());

            // assert
            result.Should().NotBeNull();
            result.Should().BeOfType<BadRequestResult>();
        }
    }
}
