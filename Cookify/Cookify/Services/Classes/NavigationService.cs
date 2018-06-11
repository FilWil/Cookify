using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cookify.Services.Classes
{
    public class NavigationService
    {
        public static async Task NavigateTo(Page page)
        {
            await Application.Current.MainPage.FadeTo(0.3);
            await Application.Current.MainPage.Navigation.PushAsync(page);
            await Application.Current.MainPage.FadeTo(1.0);
        }
    }
}
