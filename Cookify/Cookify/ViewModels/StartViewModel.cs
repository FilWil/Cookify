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
    public class StartViewModel : BaseViewModel
    {
        public Command NavigateToAddRecipeCommand { get; set; }
        public Command NavigateToAllRecipesCommand { get; set; }
        public Command NavigateToChooseIngredientsCommand { get; set; }
        public Command NavigateToFavoritesCommand { get; set; }
        public Command SearchCommand { get; set; }

        private string _search;


        public string Search
        {
            get => _search;
            set
            {
                if (_search == value) return;
                _search = value;
                OnPropertyChanged(nameof(Search));
            }
        }
        public StartViewModel()
        {
            NavigateToAddRecipeCommand = new Command(async () => await NavigateToNextPage(new AddRecipePage()));
            NavigateToAllRecipesCommand = new Command(async () => await NavigateToNextPage(new AllRecipesPage(true, null)));
            NavigateToChooseIngredientsCommand = new Command(async () => await NavigateToNextPage(new ChooseIngredientsPage()));
            NavigateToFavoritesCommand = new Command(async () => await NavigateToNextPage(new FavoritesPage()));
            SearchCommand = new Command(async () => await SearchRecipes(Search));
        }

        private async Task NavigateToNextPage(Page page)
        {
            await NavigationService.NavigateTo(page);
        }

        private async Task SearchRecipes(string searchPattern)
        {
            List<Recipe> chosenRecipesList = await App.LocalDB.GetRecipesBySearch(searchPattern);

            await NavigationService.NavigateTo(new AllRecipesPage(false, chosenRecipesList));
        }
    }
}
