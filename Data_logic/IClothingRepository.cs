using System.Collections.Generic;
using ClothingSystem.Common;

namespace ClothingSystem.DataLogic
{
    public interface IClothingRepository
    {
        void AddItem(ClothingItem item);
        List<ClothingItem> GetAllItems();
        bool RemoveItem(string CustomerName);
        List<ClothingItem> SearchByType(string type);
    }
}
