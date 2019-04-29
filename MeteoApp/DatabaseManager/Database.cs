using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MeteoApp.DatabaseManager
{
    class Database
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
            return database.QueryAsync<Entry>("SELECT * FROM [Entry]");
        }

        public Task<int> SaveCity(Entry city)
        {
            //if (city.ID == 0)
            //    return database.UpdateAsync(city);

            return database.InsertAsync(city);
        }
    }
}
