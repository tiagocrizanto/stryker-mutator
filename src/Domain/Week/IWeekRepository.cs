using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Week
{
    public interface IWeekRepository
    {
        Task<List<Day>> GetDaysOfWeek();
        Task<Day> GetDayOfWeekByDayNumber(int dayNumber);
    }
}
