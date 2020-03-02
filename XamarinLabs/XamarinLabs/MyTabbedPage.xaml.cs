using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLabs.Views;

namespace XamarinLabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTabbedPage : TabbedPage
    {
        // All Children should have TITLE Propety set.
        // Additionally we can also add images. Icons size is 30
        public MyTabbedPage()
        {
            InitializeComponent();
            Children.Add(new MoreControls());
            Children.Add(new MainPage());
            Children.Add(new AbsoluteLayoutView());
        }
    }
}