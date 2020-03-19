using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLabs.Models;
using XamarinLabs.ViewModels;

namespace XamarinLabs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaceDBView : ContentPage
    {
        PlaceDBViewModel placeDBViewModel;
        public PlaceDBView()
        {
            InitializeComponent();
            placeDBViewModel = new PlaceDBViewModel();
            BindingContext = placeDBViewModel;
        }

        public void DeleteItem(object sender, System.EventArgs e)
        {
            var place = ((MenuItem)sender).CommandParameter as PlaceDB;
            placeDBViewModel.RemoveItemCommand.Execute(place);
        }
    }
}