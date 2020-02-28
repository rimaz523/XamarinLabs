using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinLabs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoreControls : ContentPage
    {
        public List<String> Cars { get; set; }
        public MoreControls()
        {
            InitializeComponent();
            Cars = new List<String>()
            {
                "Audi", "BMW", "Ford", "Volvo"
            };
            //Tell the UI, where to get the data from by setting the binding context
            this.BindingContext = this;
        }
    }
}