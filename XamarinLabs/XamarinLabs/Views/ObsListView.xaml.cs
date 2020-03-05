using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLabs.Models;
using XamarinLabs.ViewModels;

namespace XamarinLabs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ObsListView : ContentPage
    {
        ViewModels.PlaceViewModel PVM;

        public ObsListView()
        {
            InitializeComponent();
            PVM = new PlaceViewModel();
            BindingContext = PVM;
        }


        public void DeleteItem(object sender, System.EventArgs e)
        {
            var place = ((MenuItem)sender).CommandParameter as Place;
            PVM.RemoveItemCommand.Execute(place);
        }
    }
}