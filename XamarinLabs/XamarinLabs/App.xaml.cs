using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLabs.Views;

namespace XamarinLabs
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TemplatedListView();
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
