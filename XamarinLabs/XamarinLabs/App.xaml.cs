using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLabs.Database;
using XamarinLabs.Views;

namespace XamarinLabs
{
    public partial class App : Application
    {
        static PlaceDatabase database;
        public static PlaceDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PlaceDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Places.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new PlaceDBView();
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
