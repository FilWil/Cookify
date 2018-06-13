﻿using Cookify.Models.SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using Cookify.Data;
using Cookify.Views;
using Cookify.Services.Classes;

namespace Cookify.ViewModels
{
    class AllRecipesViewModel : BaseViewModel
    {
        public ObservableCollection<Recipe> Recipes { get; set; }
        
        public AllRecipesViewModel()
        {
            Recipes = new ObservableCollection<Recipe>();

            Init();
        }

        private async void Init()
        {
            var recipes = await App.LocalDB.GetItems<Recipe>();

            foreach (var recipe in recipes)
            {
                Recipes.Add(recipe);
            }
        }
    }
}
