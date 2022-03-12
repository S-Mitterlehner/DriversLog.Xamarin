using DriversLog.Core.Interfaces;
using DriversLog.Core.Models;

namespace DriversLog.Core.Implementations
{
    public class SystemDateTimeManager : IDateTimeManager
    {
        private IEnumerable<Month> _months = new []
        {
            new Month(1, "January")
                , new Month(2, "February")
                , new Month(3, "March")
                , new Month(4, "April")
                , new Month(5, "May")
                , new Month(6, "June")
                , new Month(7, "July")
                , new Month(8, "August")
                , new Month(9, "September")
                , new Month(10, "October")
                , new Month(11, "November")
                , new Month(12, "December")
        };

        public DateTime GetNow() => DateTime.Now;

        public DateTime GetToday() => DateTime.Today;

        public IEnumerable<Month> GetMonths()
        {
            return _months;
        }
    }
}