using Domain.Week;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class WeekRepository : IWeekRepository
    {
        public async Task<List<Day>> GetDaysOfWeek()
        {
            return await Task.Run(() =>
            {
                return new List<Day> {
                    new Day{ Id = 1, Description = "Monday" },
                    new Day{ Id = 2, Description = "Sunday" },
                    new Day{ Id = 3, Description = "Tuesday" },
                    new Day{ Id = 4, Description = "Wednesday" },
                    new Day{ Id = 5, Description = "Thursday" },
                    new Day{ Id = 6, Description = "Friday" },
                    new Day{ Id = 7, Description = "Saturday" }
                };
            });
        }

        public async Task<Day> GetDayOfWeekByDayNumber(int dayNumber)
        {
            return (await GetDaysOfWeek())[dayNumber];
        }
    }
}
