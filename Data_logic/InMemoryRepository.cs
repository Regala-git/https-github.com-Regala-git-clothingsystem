using System.Collections.Generic;
using System.Linq;
using ClothingSystem.Common;

namespace ClothingSystem.DataLogic
{
    public class InMemoryRepository : IClothingRepository
    {
        private List<ClothingItem> items = new List<ClothingItem>();

        public void Add(ClothingItem item) => items.Add(item);

        public List<ClothingItem> GetAll() => new List<ClothingItem>(items);

        public bool Remove(string name)
        {
            var item = items.FirstOrDefault(i => i.Name.ToLower() == name.ToLower());
            if (item != null)
            {
                items.Remove(item);
                return true;
            }
            return false;
        }

        public List<ClothingItem> SearchByType(string type)
        {
            return items.Where(i => i.Type.ToLower() == type.ToLower()).ToList();
        }
    }
}
