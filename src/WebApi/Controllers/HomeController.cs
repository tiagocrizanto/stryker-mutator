using Application.UseCases.GetDays;
using Application.UseCases.GetDaysOfWeek;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("daysofweek")]
        public async Task<IActionResult> GetDaysOfWeek()
        {
            var output = await _mediator.Send(new GetDaysInput());
            return Ok(output);
        }

        [HttpGet("dayofweek/{dayNumber}")]
        public async Task<IActionResult> GetDayOfWeekName(int dayNumber)
        {
            var output = await _mediator.Send(new GetDayOfWeekInput { DayNumber = dayNumber });

            if (output == null)
                return BadRequest();

            return Ok(output);
        }
    }
}
