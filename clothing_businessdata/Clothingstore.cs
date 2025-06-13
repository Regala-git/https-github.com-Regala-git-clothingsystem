using ClothingSystem.Common;
using ClothingSystem.DataLogic;
using System.Collections.Generic;

namespace ClothingSystem
{
    public class Clothingstore
    {
        private IClothingRepository _repository;

        public Clothingstore(IClothingRepository repository)
        {
            _repository = repository;
        }

        public void AddClothing(string customerName, string type, string size, string color, decimal price)
        {
            var item = new ClothingItem
            {
                CustomerName = customerName,
                Type = type,
                Size = size,
                Color = color,
                Price = price
            };
            _repository.AddItem(item);
        }

        public List<ClothingItem> GetClothingItems()
        {
   
            return _repository.GetAllItems();
        }

        public bool RemoveClothing(string name)
        {
            return _repository.RemoveItem(name);
        }

        public List<ClothingItem> SearchByType(string type)
        {
            return _repository.SearchByType(type);
        }

        public void DisplayItems(List<ClothingItem> items)
        {
            foreach (var item in items)
            {
                item.Display();
            }
        }
    }
}
