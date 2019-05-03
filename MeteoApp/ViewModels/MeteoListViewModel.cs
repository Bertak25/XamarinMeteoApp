using MeteoApp.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace MeteoApp
{
    public class MeteoListViewModel : BaseViewModel
    {
        ObservableCollection<Entry> _entries;

        public ObservableCollection<Entry> Entries
        {
            get { return _entries; }
            set
            {
                _entries = value;
                OnPropertyChanged();
            }
        }

        public MeteoListViewModel(Entry current)
        {
            Entries = new ObservableCollection<Entry>();

            Entries.Add(current);
            MeteoHttpRequest.GetWeatherAsync(current);
            for (var i = 0; i < 10; i++)
            {
                var e = new Entry
                {
                    ID = i,
                    Name = "Entry " + i,
                    Latitude = 12,
                    Longitude = 12
                };
                MeteoHttpRequest.GetWeatherAsync(e);
                Entries.Add(e);
            }
        }
    }
}