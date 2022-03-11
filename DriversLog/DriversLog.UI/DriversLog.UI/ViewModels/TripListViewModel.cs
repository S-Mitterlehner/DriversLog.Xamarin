using System.Collections.ObjectModel;

namespace DriversLog.UI.ViewModels
{
    public class TripListViewModel : BaseViewModel
    {
        private ObservableCollection<Trip.Contract.Models.Trip> _trips;
        private int _selectedYear;
        private int _month;

        public int SelectedYear
        {
            get => _selectedYear;
            set
            {
                _selectedYear = value;
                OnPropertyChanged();
            }
        }

        public int Month
        {
            get => _month;
            set
            {
                _month = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Trip.Contract.Models.Trip> Trips
        {
            get => _trips;
            set
            {
                _trips = value;
                OnPropertyChanged();
            }
        }
    }
}