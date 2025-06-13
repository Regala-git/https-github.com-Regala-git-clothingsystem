using System.Collections.Generic;
using ClothingSystem.Common;


namespace ClothingSystem.DataLayer
{
    public class ClothingData
    {
        private List<ClothingItem> inventory = new List<ClothingItem>();

        public void AddItem(ClothingItem item)
        {
            inventory.Add(item);
        }

        public List<ClothingItem> GetAllItems()
        {
            return new List<ClothingItem>(inventory);
        }

        public bool RemoveItem(string CustomerName)
        {
            ClothingItem item = inventory.Find(i =>
                i.CustomerName.Equals(CustomerName, System.StringComparison.OrdinalIgnoreCase));

            if (item != null)
            {
                inventory.Remove(item);
                return true;
            }
            return false;
        }

        public List<ClothingItem> SearchByType(string type)
        {
            return inventory.FindAll(i =>
                i.Type.Equals(type, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
