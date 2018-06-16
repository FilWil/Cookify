using Cookify.Models.SQLite;
using Cookify.Services.Classes;
using Cookify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cookify.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavoritesPage : ContentPage
	{
		public FavoritesPage ()
		{
            InitializeComponent();
            var viewModel = new FavoritesViewModel();
            BindingContext = viewModel;
        }

        private async Task ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedRecipe = (Favorites) e.Item;
            await NavigationService.NavigateTo(new DetailRecipePage(selectedRecipe.RecipeId));
        }
    }
}