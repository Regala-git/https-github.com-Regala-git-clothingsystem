using ClothingSystem.Common;
using ClothingSystem.DataLogic;
using System.Collections.Generic;

namespace ClothingSystem.BusinessLogic
{
    public class Clothingstore
    {
        private readonly IClothingDataService repo;

        public Clothingstore(IClothingDataService repository)
        {
            repo = repository;
        }

        public bool AddItem(ClothingItem item)
        {
            if (!repo.Exists(item.CustomerName))
            {
                repo.AddItem(item);
                return true;
            }
            return false;
        }

        public bool RemoveItem(string customerName)
        {
            return repo.RemoveItem(customerName);
        }

        public List<ClothingItem> GetAllItems()
        {
            return repo.GetAllItems();
        }

        public List<ClothingItem> SearchByType(string type)
        {
            return repo.SearchByType(type);
        }

        public bool Exists(string customerName)
        {
            return repo.Exists(customerName);
        }
    }
}
