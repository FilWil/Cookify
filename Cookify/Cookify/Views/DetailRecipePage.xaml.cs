﻿using Cookify.ViewModels;
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
	public partial class DetailRecipePage : ContentPage
	{
		public DetailRecipePage ()
		{
            InitializeComponent();
            var viewModel = new DetailRecipeViewModel();
            BindingContext = viewModel;
        }
	}
}