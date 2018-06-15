using System;
using System.Collections.Generic;
using System.Text;
using Cookify.ViewModels;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Cookify.Models.SQLite
{
   public class Recipe
   {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string DishName { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public DateTime CreateDateTime { get; set; }

        //[OneToMany]
        [TextBlob(nameof(IngredientsBlob))]
        public List<Ingredient> Ingredients { get; set; }

        public string IngredientsBlob { get; set; }
    }
}
