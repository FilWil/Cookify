using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookify.Data;
using Cookify.Models.SQLite;
using Xamarin.Forms;

namespace Cookify.ViewModels
{
    class DetailRecipeViewModel : BaseViewModel
    {

        private string _recipeName { get; set; }
        private string _category { get; set; }
        private string _description { get; set; }
        private int _id;
        private DateTime _creationDateTime { get; set; }
        private List<Ingredient> _ingredients { get; set; }
        public Command AddRecipeToFavoriteCommand { get; set; }
        public ObservableCollection<string> IngredientsNamesCollection { get; set; }

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

        public List<Ingredient> Ingredients
        {
            get => _ingredients;
            set
            {
                if (_ingredients == value) return;
                _ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }

        public DetailRecipeViewModel(int selectedRecipeId)
        {
            
            PopulateDetails(selectedRecipeId);
            AddRecipeToFavoriteCommand = new Command(async () => await AddRecipeToFavorite());
            
        }

        public async Task AddRecipeToFavorite()
        {
            var favorite = new Favorites()
            {
                RecipeId = _id
            };

            await App.LocalDB.SaveItemAsync(favorite);
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
                //var ing = recipe.Ingredients;
                //Ingredients = ing;
                Ingredients = recipe.Ingredients;
                
            }
            
        }

        public ObservableCollection<string> ExtractIngredientNamesList(string nameBlob)
        {
                IngredientsNamesCollection = new ObservableCollection<string>();
        }
    }
}
