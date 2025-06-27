using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ClothingSystem.Common;

namespace ClothingSystem.DataLogic
{
    public class JsonFileDataService : IClothingDataService
    {
        private readonly string filePath = "clothingitems.json";

        private List<ClothingItem> LoadItems()
        {
            if (!File.Exists(filePath)) return new List<ClothingItem>();
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<ClothingItem>>(json) ?? new List<ClothingItem>();
        }

        private void SaveItems(List<ClothingItem> items)
        {
            string json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void AddItem(ClothingItem item)
        {
            var items = LoadItems();
            items.Add(item);
            SaveItems(items);
        }

        public List<ClothingItem> GetAllItems()
        {
            return LoadItems();
        }

        public List<ClothingItem> SearchByType(string type)
        {
            return LoadItems().FindAll(i => i.Type == type);
        }

        public bool RemoveItem(string customerName)
        {
            var items = LoadItems();
            var item = items.FirstOrDefault(i => i.CustomerName == customerName);
            if (item != null)
            {
                items.Remove(item);
                SaveItems(items);
                return true;
            }
            return false;
        }

        public bool Exists(string customerName)
        {
            return LoadItems().Any(i => i.CustomerName == customerName);
        }
    }
}
