﻿using System;
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
	public partial class AddRecipePage : ContentPage
	{
	    public AddRecipePage()
		{
			InitializeComponent ();
		    var viewModel = new AddRecipeViewModel();
		    BindingContext = viewModel;
        }
	}
}