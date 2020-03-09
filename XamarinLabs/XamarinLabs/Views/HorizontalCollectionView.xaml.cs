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
    public partial class HorizontalCollectionView : ContentPage
    {
        public HorizontalCollectionView()
        {
            InitializeComponent();
            BindingContext = new HorizontalCollectionViewModel();
        }
    }
}