using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinLabs.Models;

namespace XamarinLabs.ViewModels
{
    public class PlaceDBViewModel : BaseViewModel
    {
        string placeName = string.Empty;
        string description = string.Empty;
        int isFavorite = 0;
        private bool isRefreshing = false;

        public string PlaceName
        {
            get { return placeName; }
            set
            {
                SetProperty(ref placeName, value);
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
        public int IsFavorite
        {
            get { return isFavorite; }
            set
            {
                SetProperty(ref isFavorite, value);
            }
        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetProperty(ref isRefreshing, value); }
        }
        //Always use observable collections instead of lists. lists might crash
        ObservableCollection<PlaceDB> places;
        public ObservableCollection<PlaceDB> Places
        {
            get { return places; }
            set
            {
                SetProperty(ref places, value);
            }
        }
        public ICommand AddItemCommand { get; private set; }
        public ICommand RemoveItemCommand { get; private set; }
        public ICommand RefreshItemsCommand { get; private set; }
        public ICommand ShowFavoritesCommand { get; private set; }
        public PlaceDBViewModel()
        {
            Places = new ObservableCollection<PlaceDB>();
            AddItemCommand = new Command(AddItemToList);
            RemoveItemCommand = new Command(RemoveItemFromList);
            RefreshItemsCommand = new Command(RefreshListItems);
            ShowFavoritesCommand = new Command(ShowFavorites);
        }

        public void AddItemToList()
        {
            var place = new PlaceDB();
            place.PlaceName = PlaceName;
            place.Description = Description;
            place.IsFavorite = (int)IsFavorite;
            App.Database.SavePlaceAsync(place);
            RefreshListItems();
        }

        public void RemoveItemFromList(object place)
        {
            App.Database.DeletePlaceAsync(place as PlaceDB);
            Places.Remove(place as PlaceDB);
        }

        public void RefreshListItems(object sender = null)
        {
            var places = App.Database.GetAllPlacesAsync().GetAwaiter().GetResult();
            IsRefreshing = false;
            Places = new ObservableCollection<PlaceDB>();
            foreach (var place in places)
            {
                Places.Add(place);
            }
        }

        public void ShowFavorites()
        {
            IsRefreshing = true;
            var places = App.Database.GetFavoritePlacesAsync().GetAwaiter().GetResult();
            IsRefreshing = false;
            Places = new ObservableCollection<PlaceDB>();
            foreach (var place in places)
            {
                Places.Add(place);
            }
        }
    }
}
