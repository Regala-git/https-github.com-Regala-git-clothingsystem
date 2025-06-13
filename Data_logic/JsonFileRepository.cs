using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ClothingSystem.Common;

namespace ClothingSystem.DataLogic
{
    public class JsonFileRepository : IClothingRepository
    {
        private readonly string filePath = "clothing.json";

        public void AddItem(ClothingItem item)
        {
            var items = GetAllItems();
            items.Add(item);
            SaveAllItems(items);
        }

        public List<ClothingItem> GetAllItems()
        {
            if (!File.Exists(filePath)) return new List<ClothingItem>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<ClothingItem>>(json) ?? new List<ClothingItem>();
        }

        public bool RemoveItem(string CustomerName)
        {
            var items = GetAllItems();
            var item = items.Find(i => i.CustomerName.Equals(CustomerName, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                items.Remove(item);
                SaveAllItems(items);
                return true;
            }
            return false;
        }

        public List<ClothingItem> SearchByType(string type)
        {
            var items = GetAllItems();
            return items.FindAll(i => i.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
        }

        private void SaveAllItems(List<ClothingItem> items)
        {
            string json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}

