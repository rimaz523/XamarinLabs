using System.IO;
using Foundation;
using UIKit;
using XamarinLabs.Helpers;
using XamarinLabs.iOS.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSHelper))]
namespace XamarinLabs.iOS.Helpers
{
    public class IOSHelper : IPlatformHelper
    {
        public string getDocumentsPath()
        {
            var documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists("Docs"))
                Directory.CreateDirectory("Docs");
            return Path.Combine(documents, "Docs");
        }
    }
}