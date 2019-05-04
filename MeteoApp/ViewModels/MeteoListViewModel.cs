using MeteoApp.ViewModels;
using System;
using System.Collections.Generic;
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

        public MeteoListViewModel(Entry currentPosition)
        {
            Entries = new ObservableCollection<Entry>();

            MeteoHttpRequest.GetWeatherAsync(currentPosition);
            Entries.Add(currentPosition);

            //for (var i = 0; i < 10; i++)
            //{
            //    var e = new Entry
            //    {
            //        ID = i,
            //        Name = "Entry " + i,
            //        Latitude = 12,
            //        Longitude = 12
            //    };

            //    Entries.Add(e);
            //}

            //List<Entry> cities = new DatabaseManager.Database().GetAllCities().Result;

            List<Entry> cities = App.DatabaseManager.GetAllCities().Result;

            foreach (Entry e in cities)
            {
                MeteoHttpRequest.GetWeatherAsync(e);
                Entries.Add(e);
            }
        }
    }
}