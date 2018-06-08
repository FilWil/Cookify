using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Cookify.Models.SQLite
{
   public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string DishName { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }
    }
}
