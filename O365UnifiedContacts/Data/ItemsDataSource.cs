using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace O365UnifiedContacts.Data
{
    class ItemsDataSource
    {
        private static List<Item> _items;

        public static async Task<IList<Item>> GetAllItems()
        {
            if (_items == null)
            {
                var uri = new System.Uri("ms-appx:///fakenames/fakenames.json");
                var file = await StorageFile.GetFileFromApplicationUriAsync(uri);
                string fileContent = await FileIO.ReadTextAsync(file);
                _items = JsonConvert.DeserializeObject<List<Item>>(fileContent);
            }
            return _items;
        }

        internal static Item GetItemById(int parameter)
        {
            return _items.Where(i => i.Number == parameter).FirstOrDefault();
        }
    }
}
