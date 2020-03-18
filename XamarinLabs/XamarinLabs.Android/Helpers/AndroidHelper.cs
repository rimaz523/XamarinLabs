using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinLabs.Helpers;
using Xamarin.Forms;
using XamarinLabs.Droid.Helpers;

[assembly: Dependency(typeof(AndroidHelper))]
namespace XamarinLabs.Droid.Helpers
{
    public class AndroidHelper : IPlatformHelper
    {
        public string getDocumentsPath()
        {
            var documents = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "Docs");
            //var documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(documents))
                Directory.CreateDirectory(documents);
            return documents;
        }
    }
}