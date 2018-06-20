using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookify.Data;
using Cookify.Models.SQLite;
using Cookify.Views;
using Xamarin.Forms;

namespace Cookify.ViewModels
{
    public class IngredientNames
    {
        public string Name { get; set; }
    }

    class DetailRecipeViewModel : BaseViewModel
    {

        private string _recipeName { get; set; }
        private string _category { get; set; }
        private string _description { get; set; }
        private int _id;
        private DateTime _creationDateTime { get; set; }

        public Command AddRecipeToFavoriteCommand { get; set; }
        public Command RemoveRecipeCommand { get; set; }

        public ObservableCollection<IngredientNames> IngredientNamesList { get; set; }

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
            IngredientNamesList = new ObservableCollection<IngredientNames>();
            PopulateDetails(selectedRecipeId);
            _id = selectedRecipeId;
            AddRecipeToFavoriteCommand = new Command(async () => await AddRecipeToFavorite());
            RemoveRecipeCommand = new Command(async () => await RemoveRecipe());
        }

        public async Task AddRecipeToFavorite()
        {
            var favorite = new Favorites()
            {
                RecipeId = _id,
                RecipeName = _recipeName
            };

            await App.LocalDB.SaveItemAsync(favorite);
        }

        public async Task RemoveRecipe()
        {
            await App.LocalDB.RemoveRecipeById(_id);
            await NavigateToNextPage(new AllRecipesPage(true, null));
        }

        private async void PopulateDetails(int selectedRecipeId)
        {
            var recipe = await App.LocalDB.GetItems<Recipe>();
            var chosenRecipe = recipe[selectedRecipeId - 1];

            Category = chosenRecipe.Category;
            RecipeName = chosenRecipe.DishName;
            Description = chosenRecipe.Description;
            CreationDateTime = chosenRecipe.CreateDateTime;

            if(chosenRecipe.IngredientsBlob != null) ExtractIngredientNamesList(chosenRecipe.IngredientsBlob, IngredientNamesList);
        }

        public void ExtractIngredientNamesList(string nameBlob, ObservableCollection<IngredientNames> collectionOfNames)
        { 
            string[] names = nameBlob.Split(' ');

            foreach (var name in names) collectionOfNames.Add(new IngredientNames {Name = name});
        }
    }
}
