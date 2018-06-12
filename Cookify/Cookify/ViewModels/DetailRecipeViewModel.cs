using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Cookify.Data;
using Cookify.Models.SQLite;

namespace Cookify.ViewModels
{
    class DetailRecipeViewModel : BaseViewModel
    {

        private string _recipeName { get; set; }
        private string _category { get; set; }
        private string _description { get; set; }
        private DateTime _creationDateTime { get; set; }

        public string RecipeName
        {
            get => _recipeName;
            set
            {
                if (_recipeName == value) return;
                _recipeName = value;
                OnPropertyChanged(nameof(RecipeName));
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

        public DateTime CreationDateTime
        {
            get => _creationDateTime;
            set
            {
                if (_creationDateTime == value) return;
                _creationDateTime = value;
                OnPropertyChanged(nameof(CreationDateTime));
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

        public DetailRecipeViewModel(int selectedRecipeId)
        {  
            PopulateDetails(selectedRecipeId);
        }

        private async void PopulateDetails(int selectedRecipeId)
        {

            var rec = await App.LocalDB.GetItems<Recipe>();

            foreach (var recipe in rec)
            {
                if (recipe.Id != selectedRecipeId) continue;
                Category = recipe.Category;
                RecipeName = recipe.DishName;
                Description = recipe.Description;
                CreationDateTime = recipe.CreateDateTime;
            }
        }
    }
}
