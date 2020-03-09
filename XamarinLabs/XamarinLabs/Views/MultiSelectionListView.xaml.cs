using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLabs.ViewModels;

namespace XamarinLabs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MultiSelectionListView : ContentPage
    {
        public MultiSelectionListView()
        {
            InitializeComponent();
            BindingContext = new MultiSelectionListViewModel();
        }
    }
}