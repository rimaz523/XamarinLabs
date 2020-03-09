using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinLabs.Models;

namespace XamarinLabs.ViewModels
{
    public class MultiSelectionListViewModel : BaseViewModel
    {
        private ObservableCollection<Place> places;
        public ObservableCollection<Place> Places
        { 
            get { return places; }
            set { SetProperty(ref places, value); }
        }
        public ICommand ItemTappedCommand { get; private set; }

        public MultiSelectionListViewModel()
        {
            Places = new ObservableCollection<Place>()
            {
                new Place() {Name="India", Special="Known for culture"},
                new Place() {Name="Japan", Special="Known for advanced technology"},
                new Place() {Name="Bangalore", Special="IT capital of India"},
                new Place() {Name="New Zealand", Special="Known for kiwis"},
            };

            ItemTappedCommand = new Command((x) =>
            {
                var place = (x as ItemTappedEventArgs).Item as Place;
                place.IsSelected = !place.IsSelected;
            });
        }
    }
}
