using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cookify.Data;
using Cookify.Services.Interfaces;
using Cookify.Views;
using Xamarin.Forms;

namespace Cookify
{
	public partial class App : Application
	{
	    private static LocalDB _localDb;

	    public static LocalDB LocalDb
	    {
	        get
	        {
	            if (_localDb != null) return _localDb;
	            var fileHelper = DependencyService.Get<IFileHelper>();
	            var fileName = fileHelper.GetLocalFilePath("App.db3");
	            _localDb = new LocalDB(fileName);

	            return _localDb;
	        }
	    }


	    public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new StartPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
