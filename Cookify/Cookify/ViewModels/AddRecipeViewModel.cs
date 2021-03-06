﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Cookify.Models.SQLite;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Cookify.Annotations;
using Cookify.Data;
using Cookify.Services.Classes;
using Cookify.Views;

namespace Cookify.ViewModels
{
    public class AddRecipeViewModel : BaseViewModel
    {
        private string _dishName, _category, _description;

        public Command AddNewRecipeCommand { get; set; }
        public Command AddNewIngrediantCommand { get; set; }

        public List<SelectableDataService<Ingredient>> Ingredients { get; set; }


        public string DishName
        {
            get => _dishName;
            set
            {
                if (_dishName == value) return;
                _dishName = value;
                OnPropertyChanged(nameof(DishName));
            }
        }

        public string Category
        {
            get => _category;
            set
            {
                if (_category == value) return;
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description == value) return;
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public AddRecipeViewModel()
        {
            AddNewRecipeCommand = new Command(async () => await AddNewRecipe());
            AddNewIngrediantCommand = new Command(async () => await NavigateToNextPage(new AddIngredientPage()));
            
            Ingredients = new List<SelectableDataService<Ingredient>>();
            Init();
        }

        private async Task AddNewRecipe()
        {
            var recipe = new Recipe
            {
                DishName = DishName,
                CreateDateTime = DateTime.Now,
                Description = Description,
                Category = Category,
                IngredientsBlob = GetIngredientsNames()
            };

            await App.LocalDB.SaveItemAsync(recipe);

            await NavigateToNextPage(new AllRecipesPage(true, null));
        }

        public string GetIngredientsNames()
        {
            var namesBlob = new StringBuilder();

            foreach (var data in Ingredients)
            {
                if (data.Selected)
                {
                    namesBlob.Append(data.Data + " ");
                }
            }

            namesBlob.Remove(namesBlob.Length - 1, 1);

            return namesBlob.ToString();
        }

        private async void Init()
        {
            var ingredients = await App.LocalDB.GetItems<Ingredient>();

            foreach (var ingredient in ingredients)
            {
                Ingredients.Add(new SelectableDataService<Ingredient>() { Data = ingredient.Name, Selected = false });
            }
        }
    }
}
