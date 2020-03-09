using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinLabs.Models;

namespace XamarinLabs.ViewModels
{
    public class HorizontalCollectionViewModel
    {
        public ObservableCollection<Phone> Phones { get; set; } = new ObservableCollection<Phone>();

        public HorizontalCollectionViewModel()
        {
            Phones.Add(new Phone()
            {
                Model = "A70S",
                Brand = "Samsung",
                ImageSource = "samsung_s20.jpg"
            });
            Phones.Add(new Phone()
            {
                Model = "S20 Ultra",
                Brand = "Samsung",
                ImageSource = "samsung_s20.jpg"
            });
            Phones.Add(new Phone()
            {
                Model = "11 pro",
                Brand = "Iphone",
                ImageSource = "samsung_s20.jpg"
            });
        }
    }
}
