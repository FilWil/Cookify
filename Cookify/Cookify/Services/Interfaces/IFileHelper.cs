using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Cookify.Services.Interfaces
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string fileName);
    }
}
