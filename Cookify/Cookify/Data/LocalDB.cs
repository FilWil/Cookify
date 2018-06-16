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

        internal async Task<List<Recipe>> GetRecipesBySearch(string searchPattern)
        {
            searchPattern = searchPattern.ToLower();
                return await database.Table<Recipe>().Where(r => r.DishName.ToLower().Contains(searchPattern))
                    .ToListAsync();
        }

        internal async Task<List<Recipe>> GetRecipesByChosenIngredients(List<Ingredient> Ingredients)
        {
            var ingredientNamesFromRecipes = new List<string>();

            var recipes = await database.Table<Recipe>().ToListAsync();
            int[] priorityList = new int[recipes.Count];

            foreach (var recipe in recipes)
            {
                ingredientNamesFromRecipes.Add(recipe.IngredientsBlob);
            }

            string[] names = ingredientNamesFromRecipes.ToArray();

            for(var i = 0; i < names.Length; i++)
            {
                string[] namesOfSelected = names[i].Split(' ');
                foreach (var name in namesOfSelected)
                {
                    foreach(var nameFromRecipe in Ingredients)
                    {
                        if (nameFromRecipe.Name == name) priorityList[i] += 1;
                    }
                }
            }

            var FinalSelection = new List<Recipe>();

            for(int i = 0; i < priorityList.Length; i++)
            {
                if (priorityList[i] > 0)
                {
                    FinalSelection.Add(recipes[i]);
                }
            }

            return FinalSelection;
        }
    }
}
