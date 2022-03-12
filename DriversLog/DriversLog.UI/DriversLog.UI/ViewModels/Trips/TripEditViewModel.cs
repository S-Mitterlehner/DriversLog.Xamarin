using System;
using System.Threading.Tasks;
using DriversLog.Core.Interfaces;
using DriversLog.Trip.Contract;
using MvvmCross.Commands;

namespace DriversLog.UI.ViewModels.Trips
{
    public class TripEditViewModel : BaseViewModel
    {
        private readonly ITripManager _manager;
        private readonly IDateTimeManager _dtManager;
        private string _from;
        private string _destination;
        private int? _distance;
        private TimeSpan? _departure;
        private TimeSpan? _arrival;
        private DateTime? _date;
        
        public MvxAsyncCommand SaveCommand { get; }

        public TripEditViewModel(ITripManager manager, IDateTimeManager dtManager)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
            _dtManager = dtManager ?? throw new ArgumentNullException(nameof(dtManager));

            SaveCommand = new MvxAsyncCommand(SaveAsync, CanSave);
        }

        public string From
        {
            get => _from;
            set
            {
                _from = value;
                OnPropertyChanged();
            }
        }

        public string Destination
        {
            get => _destination;
            set
            {
                if (_destination != value)
                {
                    _destination = value;
                    OnPropertyChanged();
                }
            }
        }

        public int? Distance
        {
            get => _distance;
            set
            {
                if (_distance != value)
                {
                    _distance = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime? Date
        {
            get => _date ?? (_date = _dtManager.GetToday());
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged();
                }
            }
        }

        public TimeSpan? Departure
        {
            get => _departure;
            set
            {
                if (_departure != value)
                {
                    _departure = value;
                    OnPropertyChanged();
                }
            }
        }

        public TimeSpan? Arrival
        {
            get => _arrival;
            set
            {
                if (_arrival != value)
                {
                    _arrival = value;
                    OnPropertyChanged();
                }
            }
        }

        private async Task SaveAsync()
        {
            
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(From)
                && !string.IsNullOrWhiteSpace(Destination)
                && Departure.HasValue
                && Arrival.HasValue
                && Distance > 0;
        }
    }
}