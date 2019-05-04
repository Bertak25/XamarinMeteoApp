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
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}