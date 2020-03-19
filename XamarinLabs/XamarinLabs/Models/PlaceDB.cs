using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinLabs.Models
{
    public class PlaceDB
    {
        [PrimaryKey, AutoIncrement]
        public int PlaceID { get; set; }
        public string PlaceName { get; set; }
        public string Description { get; set; }
        public int IsFavorite { get; set; }
    }
}
