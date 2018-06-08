using System;
using System.Collections.Generic;
using System.Text;

namespace Cookify.Services.Interfaces
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string fileName);
    }
}
