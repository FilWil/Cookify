using System;
using System.Collections.Generic;
using System.Text;

namespace Cookify.Services.Classes
{
    public class SelectableDataService<T>
    {
        public string Data { get; set; }
        public bool Selected { get; set; }
    }
}
