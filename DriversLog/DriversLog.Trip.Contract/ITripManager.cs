using DriversLog.Core.Interfaces;

namespace DriversLog.Trip.Contract
{
    public interface ITripManager : IManager<Models.Trip>
    {
        Task<IEnumerable<Models.Trip>> GetTripsByYearAndMonth(int year, int month);
        Task<Models.Trip> GetById(int id);
        Task Save(Models.Trip trip);
        Task Delete(int id);
    }
}