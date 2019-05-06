using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MeteoApp.DatabaseManager
{
    public class Database
    {
        private readonly SQLiteAsyncConnection database;

        /// <summary>
        /// Constructor
        /// </summary>
        public Database()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "meteoapp");
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Entry>().Wait();
        }

        public Task<List<Entry>> GetAllCities()
        {
            return database.QueryAsync<Entry>("SELECT * FROM [Entry] order by [Name];");
        }

        public Task<int> SaveCity(Entry city)
        {
            return database.InsertAsync(city);
        }
    }
}
