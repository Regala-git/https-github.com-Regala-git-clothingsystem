using ClothingSystem.Common;
using ClothingSystem.DataLayer;
using System.Collections.Generic;

namespace ClothingSystem.BusinessLogic
{
    public class ClothingService
    {
        private ClothingData data = new ClothingData();

        public bool AddClothing(string name, string type, string size, string color, decimal price)
        {
            ClothingItem item = new ClothingItem
            {
                Name = name,
                Type = type,
                Size = size,
                Color = color,
                Price = price
            };
            data.AddItem(item);
            return true;
        }

        public List<ClothingItem> GetClothingItems()
        {
            return data.GetAllItems();
        }

        public bool RemoveClothing(string name)
        {
            return data.RemoveItem(name);
        }

        public List<ClothingItem> SearchByType(string type)
        {
            return data.SearchByType(type);
        }
    }
}
