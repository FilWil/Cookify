using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookify.Models.SQLite;
using Cookify.Services.Classes;
using Cookify.Views;
using Xamarin.Forms;

namespace Cookify.ViewModels
{
    
    public class ChooseIngredientsViewModel : BaseViewModel
    {
        public List<SelectableDataService<Ingredient>> Ingredients { get; set; }

        public Command FindRecipesBasedOnSelectionCommand { get; set; }

        public ChooseIngredientsViewModel()
        {
            Ingredients = new List<SelectableDataService<Ingredient>>();
            FindRecipesBasedOnSelectionCommand = new Command(async () => await ChooseCorrectRecipes());
            Init();
        }

        private async void Init()
        {
            var ingredients = await App.LocalDB.GetItems<Ingredient>();
            
            foreach (var ingredient in ingredients)
            {
                Ingredients.Add(new SelectableDataService<Ingredient>() { Data = ingredient.Name, Selected = false });
            }
        }

        private async Task ChooseCorrectRecipes()
        {
            var list = new List<Ingredient>();

            foreach (var data in Ingredients)
            {
                if (data.Selected)
                {
                    list.Add(new Ingredient() { Name = data.Data });
                }
            }

            List<Recipe> chosenRecipesList = await App.LocalDB.GetRecipesByChosenIngredients(list);

            await NavigationService.NavigateTo(new AllRecipesPage(false, chosenRecipesList));
        }
    }
}
