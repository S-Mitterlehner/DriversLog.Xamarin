using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DriversLog.Core.Interfaces;
using DriversLog.Core.Models;
using DriversLog.Trip.Contract;
using MvvmCross.Commands;
using Xamarin.Forms;

namespace DriversLog.UI.ViewModels.Trips
{
    public class TripListViewModel : BaseViewModel
    {
        private readonly ITripManager _manager;
        private readonly IDateTimeManager _dtManager;
        private ObservableCollection<Trip.Contract.Models.Trip> _trips;
        private int _selectedYear;
        private Month _selectedMonth;
        private IEnumerable<Month> _months;

        public MvxAsyncCommand AddCommand { get; }
        public MvxAsyncCommand ReloadTripsCommand { get; }

        public TripListViewModel(ITripManager manager, IDateTimeManager dtManager)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
            _dtManager = dtManager ?? throw new ArgumentNullException(nameof(dtManager));
            AddCommand = new MvxAsyncCommand(async () => await Shell.Current.GoToAsync(Routes.NewTrip));
            ReloadTripsCommand = new MvxAsyncCommand(LoadTripsAsync, CanLoadTrips);
        }
        
        public int SelectedYear
        {
            get => _selectedYear;
            set
            {
                _selectedYear = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<Month> Months => _months ?? (_months = _dtManager.GetMonths());

        public Month SelectedMonth
        {
            get => _selectedMonth;
            set
            {
                _selectedMonth = value;
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

        public override async Task InitializeAsync()
        {
            await LoadTripsAsync();
        }

        private async Task LoadTripsAsync()
        {
            var items = await _manager.GetTripsByYearAndMonth(SelectedYear, SelectedMonth.Number);
            Trips = new ObservableCollection<Trip.Contract.Models.Trip>(items);
        }

        private bool CanLoadTrips()
        {
            return SelectedYear > 0 && SelectedMonth != null;
        }
    }
}