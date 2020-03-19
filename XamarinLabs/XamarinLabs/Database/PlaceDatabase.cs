using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using XamarinLabs.Models;

namespace XamarinLabs.Database
{
    public class PlaceDatabase
    {
        readonly SQLiteAsyncConnection database;
        public PlaceDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<PlaceDB>();
        }

        public Task<PlaceDB> GetPlaceAsync(int id)
        {
            return database.Table<PlaceDB>().Where(i => i.PlaceID == id).FirstOrDefaultAsync();
        }

        public Task<List<PlaceDB>> GetAllPlacesAsync()
        {
            return database.Table<PlaceDB>().OrderBy(i => i.PlaceID).ToListAsync();
        }

        public Task<int> SavePlaceAsync(PlaceDB place)
        {
            if (place.PlaceID != 0)
            {
                return database.UpdateAsync(place);
            }
            else
            {
                return database.InsertAsync(place);
            }
        }

        public Task<List<PlaceDB>> GetFavoritePlacesAsync()
        {
            return database.QueryAsync<PlaceDB>("SELECT * FROM [PlaceDB] WHERE IsFavorite=1");
        }

        public Task<int> DeletePlaceAsync(PlaceDB place)
        {
            return database.DeleteAsync(place);
        }
    }
}
