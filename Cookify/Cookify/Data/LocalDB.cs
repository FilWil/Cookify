using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Cookify.Data
{
    public class LocalDB
    {
        private readonly SQLiteAsyncConnection database;

        public LocalDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

        }
    }
}
