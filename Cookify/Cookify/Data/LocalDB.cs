using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookify.Models.SQLite;
using SQLite;

namespace Cookify.Data
{
    public class LocalDB
    {
        readonly SQLiteAsyncConnection database;

        public LocalDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            //database.DropTableAsync<Recipe>().Wait();
            //database.DropTableAsync<Ingredient>().Wait();
            //database.DropTableAsync<Favorites>().Wait();
            database.CreateTableAsync<Recipe>().Wait();
            database.CreateTableAsync<Ingredient>().Wait();
            database.CreateTableAsync<Favorites>().Wait();
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

        internal async Task<List<Recipe>> GetAllRecipes()
        {
            return await database.Table<Recipe>().ToListAsync();
        }

        internal async Task<List<T>> GetItems<T>() where T : class, new()
        {
            return await database.Table<T>().ToListAsync();
        }

        internal async Task<List<Recipe>> GetRecipesByChosenIngredients(List<Ingredient> Ingredients)
        {
            var ingredientNamesFromRecipes = new List<string>();
            var ingredientNamesFromIngredients = new StringBuilder();

            var recipes = await database.Table<Recipe>().ToListAsync();

            foreach (var recipe in recipes)
            {
                ingredientNamesFromRecipes.Add(recipe.IngredientsBlob);
            }

            //"mąka jajko woda"
            //"dzem ser jajko"

            foreach (var ingredient in Ingredients)
            {
                ingredientNamesFromIngredients.Append(ingredient.Name + " ");
            }

            ingredientNamesFromIngredients.Remove(ingredientNamesFromIngredients.Length -1 , 1);

            //for (int i = 0; i < ingredientNamesFromRecipes.Count; i++)
            //{
            //    if(ingredientNamesFromRecipes[i] == )
            //}

            //ingredientNamesFromRecipes.Where(ing => ing.)

            //return await database.Table<Recipe>().Where()
        }
    }
}
