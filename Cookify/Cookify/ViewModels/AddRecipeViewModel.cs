﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Cookify.Models.SQLite;
using Xamarin.Forms;

namespace Cookify.ViewModels
{
    public class AddRecipeViewModel : BaseViewModel
    {
        private string _dishName, _category, _description;
        private DateTime _createDateTime;
        private ObservableCollection<Ingredient> _ingredients;
        public Command AddNewRecipeCommand { get; set; }

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
        }

        private async Task AddNewRecipe()
        {
            var recipe = new Recipe
            {
                DishName = DishName,
                CreateDateTime = DateTime.Now,
                Description = Description
            };

            await App.LocalDb.SaveItemAsync(recipe);
        }
    }
}
