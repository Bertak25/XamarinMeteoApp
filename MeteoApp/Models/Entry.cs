using SQLite;
using System;

namespace MeteoApp
{
    public class Entry
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string IconURL { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Weather { get; set; }
        public double Temp { get; set; }
        public double Humidity { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public double WindSpeed { get; set; }
    }
}