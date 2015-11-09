using O365UnifiedContacts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Devices.Geolocation;
using Windows.Foundation;

namespace O365UnifiedContacts.ViewModels
{
    public class ItemViewModel
    {
        public Data.Item Item { get; set; }

        public ItemViewModel(Data.Item source )
        {
            this.Item = source;
        }

        public string DisplayAddress
        {
            get
            {
                var s = Item.StreetAddress;
                if (!string.IsNullOrEmpty(Item.StateFull))
                {
                    s += $", {Item.StateFull}";
                }
                if (!string.IsNullOrEmpty(Item.CountryFull))
                {
                    s += $", {Item.CountryFull}";
                }
                return s;
            }
        }

        public string OccupationCompany
        {
            get
            {
                return $"{Item.Occupation}, {Item.Company}";
            }
        }

        public string UserPhoto
        {
            get
            {
                char startsWith = this.Item.Surname[0];
                var photoIndex = Array.IndexOf("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(), startsWith);

                string root = @"ms-appx:///";
                string path = root + @"Assets/People/" + this.Item.Gender + "/" + photoIndex + ".png";
                return path;
            }
        }

        public Geopoint Location
        {
            get
            {
                return new Geopoint(
                    new BasicGeoposition()
                    {
                        Latitude = this.Item.Latitude,
                        Longitude = this.Item.Longitude
                    }
                    );
            }
        }

    }
}
