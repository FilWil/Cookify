using Cookify.Models.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cookify.ViewModels
{
    class AddIngredientViewModel : BaseViewModel
    {
        public Command AddNewIngredientCommand { get; set; }
        private string _name;

        public string IngName
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged(nameof(IngName));
            }
        }

        public AddIngredientViewModel()
        {
            AddNewIngredientCommand = new Command(async () => await AddNewIngredient());
        }

        private async Task AddNewIngredient()
        {
            var ingredient = new Ingredient()
            {
                Name = IngName
            };

            await App.LocalDB.SaveItemAsync(ingredient);
        }
    }
}
