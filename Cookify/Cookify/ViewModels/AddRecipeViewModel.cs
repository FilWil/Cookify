using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Cookify.Models.SQLite;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Cookify.Annotations;
using Cookify.Services.Classes;
using Cookify.Views;

namespace Cookify.ViewModels
{
    public class SelectableData<T>
    {
        public string Data { get; set; }
        public bool Selected { get; set; }
    }

    public class AddRecipeViewModel : BaseViewModel
    {
        private string _dishName, _category, _description;
        private DateTime _createDateTime;
        //public ObservableCollection<Ingredient> Ingredients;
        public Command AddNewRecipeCommand { get; set; }
        public Command AddNewIngrediantCommand { get; set; }

        public List<SelectableData<Ingredient>> Ingredients { get; set; }


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
            
            Ingredients = new List<SelectableData<Ingredient>>();
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
                Ingredients = getIngredients()
            };

            System.Diagnostics.Debug.WriteLine("ILOŚć SKŁADNIKów ::: " + recipe.Ingredients.Count);

            await App.LocalDB.SaveItemAsync(recipe);

            await NavigateToNextPage(new AllRecipesPage());
        }

        public List<Ingredient> getIngredients()
        {
            var list = new List<Ingredient>();

            foreach (var data in Ingredients)
            {
                if (data.Selected == true)
                {
                    list.Add(new Ingredient() { Name = data.Data });
                }
            }

            return list;
        }


        private async void Init()
        {
            var ingredients = await App.LocalDB.GetItems<Ingredient>();

            foreach (var ingredient in ingredients)
            {
                Ingredients.Add(new SelectableData<Ingredient>() { Data = ingredient.Name, Selected = false });
            }
        }
    }
}
