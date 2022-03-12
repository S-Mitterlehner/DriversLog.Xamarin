using DriversLog.Core.Models;

namespace DriversLog.Core.Interfaces
{
    public interface IDateTimeManager
    {
        DateTime GetNow();
        DateTime GetToday();

        IEnumerable<Month> GetMonths();
    }
}