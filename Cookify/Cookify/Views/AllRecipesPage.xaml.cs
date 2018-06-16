using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookify.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cookify.Models;
using Cookify.Models.SQLite;
using Cookify.Services.Classes;

namespace Cookify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllRecipesPage : ContentPage
    {
        public AllRecipesPage(bool isViewEverything, List<Recipe> selectionOfRecipes)
        {
            InitializeComponent();
            AllRecipesViewModel viewModel;

            if (isViewEverything) viewModel = new AllRecipesViewModel();
            else viewModel = new AllRecipesViewModel(selectionOfRecipes);

            BindingContext = viewModel;
        }

        private async Task ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedRecipe = ((ListView)sender).SelectedItem as Recipe;
            await NavigationService.NavigateTo(new DetailRecipePage(selectedRecipe.Id));
        }
    }
}