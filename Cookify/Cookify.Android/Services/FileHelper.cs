using System.IO;
using Cookify.Droid.Services;
using Cookify.Services.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(FileHelper))]
namespace Cookify.Droid.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}