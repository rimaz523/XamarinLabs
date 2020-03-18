using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using XamarinLabs.Helpers;

namespace XamarinLabs
{
    public static class Files
    {

        public static string AccessAppFolder()
        {
            return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyFile.txt"); // This is where app stores data. the app filesystem
        }

        public static string OpenSharedFile()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Files)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("XamarinLabs.Files.MyFile.txt");
            string text = "";
            using (var reader = new StreamReader(stream))
                text = reader.ReadToEnd();
            return text;
        }

        public static string getDocuments()
        {
            return DependencyService.Get<IPlatformHelper>().getDocumentsPath();
        }
    }
}
