using System.Collections.Generic;
using System.Linq;
using ClothingSystem.Common;

namespace ClothingSystem.DataLogic
{
    public class InMemoryDataService : IClothingDataService
    {
        private readonly List<ClothingItem> items = new();

        public void AddItem(ClothingItem item)
        {
            items.Add(item);
        }

        public List<ClothingItem> GetAllItems()
        {
            return new List<ClothingItem>(items);
        }

        public List<ClothingItem> SearchByType(string type)
        {
            return items.FindAll(item => item.Type == type);
        }

        public bool RemoveItem(string customerName)
        {
            var item = items.FirstOrDefault(i => i.CustomerName == customerName);
            if (item != null)
            {
                items.Remove(item);
                return true;
            }
            return false;
        }

        public bool Exists(string customerName)
        {
            return items.Any(i => i.CustomerName == customerName);
        }
    }
}
