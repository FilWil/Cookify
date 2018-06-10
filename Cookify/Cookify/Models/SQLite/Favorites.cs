using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookify.Models.SQLite
{
    class Favorites
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Recipe))]
        public int RecipeId { get; set; }
    }
}
