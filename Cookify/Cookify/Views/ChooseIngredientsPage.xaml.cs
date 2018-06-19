using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookify.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cookify.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChooseIngredientsPage : ContentPage
	{
	    public ChooseIngredientsPage()
	    {
	        InitializeComponent();
            var viewModel = new ChooseIngredientsViewModel();
    		BindingContext = viewModel;
		}
	}
}