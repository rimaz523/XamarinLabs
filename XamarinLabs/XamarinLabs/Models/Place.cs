using System;
using System.Collections.Generic;
using System.Text;
using XamarinLabs.ViewModels;

namespace XamarinLabs.Models
{
    public class Place: BaseViewModel
    {
        public string Name { get; set; }
        public string Special { get; set; }
        private bool isSelected;
        private string selectionImage;
        public bool IsSelected 
        { 
            get { return isSelected; }
            set { SetProperty(ref isSelected, value);
                SelectionImage = isSelected ? "tick.png" : null;
            }
        }
        public string SelectionImage
        { 
            get { return selectionImage; }
            set { SetProperty(ref selectionImage, value); }
        }
    }
}
