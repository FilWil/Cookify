using Cookify.Models.SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Cookify.ViewModels
{
    class FavoritesViewModel : BaseViewModel
    {
        public ObservableCollection<Favorites> Favorites { get; set; }


        public FavoritesViewModel()
        {
            Favorites = new ObservableCollection<Favorites>();
            Init();
        }

        private async void Init()
        {
            var favorites = await App.LocalDB.GetItems<Favorites>();

            foreach (var fav in favorites)
            {
                Favorites.Add(fav);
            }
        }
    }
}
