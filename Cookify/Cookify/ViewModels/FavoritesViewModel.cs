using Cookify.Models.SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Cookify.ViewModels
{
    class FavoritesViewModel : BaseViewModel
    {
        private ObservableCollection<Favorites> _favorites;

        public FavoritesViewModel()
        {
            _favorites = new ObservableCollection<Favorites>();
        }
    }
}
