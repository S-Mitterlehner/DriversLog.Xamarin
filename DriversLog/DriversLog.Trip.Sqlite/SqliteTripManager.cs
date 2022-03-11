using DriversLog.Trip.Contract;
using SQLite;

namespace DriversLog.Trip.Sqlite
{
    public class SqliteTripManager : ITripManager
    {
        private readonly SQLiteAsyncConnection _conn;

        public SqliteTripManager(string dbPath)
        {
            if (dbPath == null) throw new ArgumentNullException(nameof(dbPath));
            _conn = new SQLiteAsyncConnection(dbPath);
        }

        public async Task Initialize()
        {
            await _conn.CreateTableAsync<Contract.Models.Trip>();
        }

        public async Task<IEnumerable<Contract.Models.Trip>> GetTripsByYearAndMonth(int year, int month) =>
            await _conn.Table<Contract.Models.Trip>()
                       .Where(t => t.Departure.Year == year && t.Departure.Month == month)
                       .ToListAsync();

        public Task<Contract.Models.Trip> GetById(int id) => 
            _conn.Table<Contract.Models.Trip>()
                 .FirstOrDefaultAsync(t => t.Id == id);

        public async Task Save(Contract.Models.Trip trip)
        {
            if (trip.Id <= 0)
            {
                await _conn.InsertAsync(trip);
            }
            else
            {
                await _conn.UpdateAsync(trip);
            }
        }

        public async Task Delete(int id)
        {
            if (id <= 0)
            {
                return;
            }

            await _conn.DeleteAsync(id);
        }
    }
}