using System.Collections.Generic;
using System;
using ClothingSystem.Common;

namespace ClothingSystem.DataLogic
{
    public class InMemoryRepository : IClothingRepository
    {
        private List<ClothingItem> items = new List<ClothingItem>();

        public void AddItem(ClothingItem item)
        {
            items.Add(item);
        }

        public List<ClothingItem> GetAllItems()
        {
            return new List<ClothingItem>(items);
        }

        public bool RemoveItem(string CustomerName)
        {
            var item = items.Find(i => i.CustomerName.Equals(CustomerName, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                items.Remove(item);
                return true;
            }
            return false;
        }

        public List<ClothingItem> SearchByType(string type)
        {
            return items.FindAll(i => i.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
        }
    }
}
