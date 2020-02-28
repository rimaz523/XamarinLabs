using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLabs.ViewModels;

namespace XamarinLabs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();
            BindingContext = new ListViewViewModel();
        }
    }
}