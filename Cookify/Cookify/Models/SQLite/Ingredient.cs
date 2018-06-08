using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Cookify.Models.SQLite
{
    public class Ingredient
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
