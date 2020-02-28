using System;
using System.Collections.Generic;
using System.Text;
using XamarinLabs.Models;

namespace XamarinLabs.ViewModels
{
    class ListViewViewModel
    {
        public List<CarModel> Cars { get; set; }
        public ListViewViewModel()
        {
            Cars = new List<CarModel>()
            {
                new CarModel(){ Name="Quattro", Make="Audi", Desc="This is adescription for Audi.This is adescription for Audi.This is adescription for Audi.This is adescription for Audi.This is adescription for Audi." },
                new CarModel(){ Name="GT500", Make="Ford", Desc="This is adescription for Ford.This is adescription for Ford.This is adescription for Ford.This is adescription for Ford.This is adescription for Ford.This is adescription for Ford." }
            };
        }
    }
}
