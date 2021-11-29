using System.Collections.Generic;

namespace sample_stryker
{
    public class CollectionOperations
    {
        public string GetDayOfWeek(int dayNumber)
        {
            if (dayNumber <= 0 || dayNumber > 7) return "Invalid day";

            var daysOfWeek = new List<string> { "Monday", "Sunday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            return daysOfWeek[dayNumber];
        }

        public List<string> GetDaysOfWeek(int dayNumber) => new List<string> { "Monday", "Sunday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        public List<SampleObject> GetObjects()
        {
            return new List<SampleObject>
            {
                new SampleObject
                {
                    Description = "Object description",
                    Id = 1,
                    Name = "Object Name"
                }
            };
        }
}
}
