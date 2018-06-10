using Cookify.Models.SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace Cookify.ViewModels
{
    class AllRecipesViewModel : BaseViewModel
    {
        public ObservableCollection<Recipe> Recipes { get; set; }
        private string _dishname, _category;

        public string DishName
        {
            get => _dishname;
            set
            {
                if (_dishname != value)
                {
                    _dishname = value;
                    RaisePropertyChanged(nameof(DishName));
                }
            }
        }

        public string Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    RaisePropertyChanged(nameof(Category));
                }
            }
        }

        public AllRecipesViewModel()
        {
            Init();
            Recipes = new ObservableCollection<Recipe>();
        }

        public string DishDescription
        {
            get
            {
                return string.Format("{0} - {1}", DishName, Category);
            }
        }

        private async void Init()
        {
           
        }
    }
}
