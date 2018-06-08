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
        public Command NavigateToAddRecipeCommand { get; private set; }

        public StartViewModel()
        {
            NavigateToAddRecipeCommand = new Command(async () => await NavigateToAddRecipe());
        }

        private async Task NavigateToAddRecipe()
        {
            await NavigationService.NavigateTo(new AddRecipePage());
        }
    }
}
