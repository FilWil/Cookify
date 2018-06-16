using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public StartViewModel()
        {
            NavigateToAddRecipeCommand = new Command(async () => await NavigateToNextPage(new AddRecipePage()));
            NavigateToAllRecipesCommand = new Command(async () => await NavigateToNextPage(new AllRecipesPage(true, null)));
            NavigateToChooseIngredientsCommand = new Command(async () => await NavigateToNextPage(new ChooseIngredientsPage()));
            NavigateToFavoritesCommand = new Command(async () => await NavigateToNextPage(new FavoritesPage()));
        }

        private async Task NavigateToNextPage(Page page)
        {
            await NavigationService.NavigateTo(page);
        }
    }
}
