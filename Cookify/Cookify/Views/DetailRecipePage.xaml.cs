using Cookify.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookify.Models.SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cookify.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailRecipePage : ContentPage
	{
	    


        public DetailRecipePage(int selectedRecipeId)
        {

            InitializeComponent();
            var viewModel = new DetailRecipeViewModel(selectedRecipeId);
            BindingContext = viewModel;
        }

        
    }
}