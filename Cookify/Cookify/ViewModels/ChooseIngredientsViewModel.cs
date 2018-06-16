using System;
using System.Collections.Generic;
using System.Text;
using Cookify.Models.SQLite;
using Cookify.Services.Classes;

namespace Cookify.ViewModels
{
    public class ChooseIngredientsViewModel : BaseViewModel
    {
        public List<SelectableDataService<Ingredient>> Ingredients { get; set; }

        public ChooseIngredientsViewModel()
        {
            Ingredients = new List<SelectableDataService<Ingredient>>();
            Init();
        }

        private async void Init()
        {
            var ingredients = await App.LocalDB.GetItems<Ingredient>();

            foreach (var ingredient in ingredients)
            {
                Ingredients.Add(new SelectableDataService<Ingredient>() { Data = ingredient.Name, Selected = false });
            }
        }
    }
}
