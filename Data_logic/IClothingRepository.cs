using System.Collections.Generic;

namespace ClothingSystem.Common
{
    public interface IClothingRepository
    {
        List<ClothingItem> GetAll();
        void Add(ClothingItem item);
        bool Remove(string name);
        List<ClothingItem> SearchByType(string type);
    }
}
