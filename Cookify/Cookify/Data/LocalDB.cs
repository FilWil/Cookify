using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookify.Models.SQLite;
using SQLite;

namespace Cookify.Data
{
    public class LocalDB
    {
        private readonly SQLiteAsyncConnection database;

        public LocalDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Recipe>().Wait();
            database.CreateTableAsync<Ingredient>();
        }

        public async Task<int> SaveItemAsync<T>(T item)
        {
            var result = await database.UpdateAsync(item);

            if (result == 0)
                result = await database.InsertAsync(item);

            return result;
        }

        internal async Task<Recipe> GetRecipeById(int id)
        {
            return await database.Table<Recipe>().Where(r => r.Id == id).FirstOrDefaultAsync();
        }
    }
}
