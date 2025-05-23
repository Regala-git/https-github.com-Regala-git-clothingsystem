using System.Collections.Generic;
using ClothingSystem.Common;

namespace ClothingSystem.BusinessLogic
{
    public class ClothingService
    {
        private IClothingRepository _repo;

        public ClothingService(IClothingRepository repo)
        {
            _repo = repo;
        }

        public void AddClothing(string name, string type, string size, string color, decimal price)
        {
            _repo.Add(new ClothingItem
            {
                Name = name,
                Type = type,
                Size = size,
                Color = color,
                Price = price
            });
        }

        public List<ClothingItem> GetClothingItems() => _repo.GetAll();

        public bool RemoveClothing(string name) => _repo.Remove(name);

        public List<ClothingItem> SearchByType(string type) => _repo.SearchByType(type);
    }
}
