using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinLabs.Models;

namespace XamarinLabs.ViewModels
{
    public class PlaceViewModel : BaseViewModel
    {
        string name = string.Empty;
        string description = string.Empty;
        private bool isRefreshing = false;

        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                SetProperty(ref description, value);
            }
        }

        public bool IsRefreshing
        { 
            get { return isRefreshing; }
            set { SetProperty(ref isRefreshing, value); }
        }
        //Always use observable collections instead of lists. lists might crash
        ObservableCollection<Place> places;
        public ObservableCollection<Place> Places
        { 
            get { return places; }
            set {
                SetProperty(ref places, value);
            }
        }
        public ICommand AddItemCommand { get; private set; }
        public ICommand RemoveItemCommand { get; private set; }
        public ICommand RefreshItemsCommand { get; private set; }
        public PlaceViewModel()
        {
            Places = new ObservableCollection<Place>();
            AddItemCommand = new Command(AddItemToList);
            RemoveItemCommand = new Command(RemoveItemFromList);
            RefreshItemsCommand = new Command(RefreshListItems);
        }

        public void AddItemToList()
        {
            var place = new Place
            {
                Name = Name,
                Special = Description
            };
            Places.Add(place);
            Name = "";
            Description = "";
        }

        public void RemoveItemFromList(object place)
        {
            Places.Remove(place as Place);
        }

        public void RefreshListItems(object sender)
        {
            //Call the Api again and get the data
            //Update the List View that refreshing is complete
            Device.StartTimer(new TimeSpan(0, 0, 5), () =>
            {
                Device.BeginInvokeOnMainThread(() => {
                    IsRefreshing = false;
                });
                return false;
            });

        }
    }
}
