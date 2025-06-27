using System.Collections.Generic;

namespace ClothingSystem.Common
{
    public interface IClothingDataService
    {
        void AddItem(ClothingItem item);
        List<ClothingItem> GetAllItems();
        List<ClothingItem> SearchByType(string type);
        bool RemoveItem(string customerName);
        bool Exists(string customerName);
    }
}

