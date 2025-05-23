using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using ClothingSystem.Common;

namespace ClothingSystem.DataLogic
{
    public class JsonFileRepository : IClothingRepository
    {
        private string filePath = "clothing.json";
        private List<ClothingItem> items = new List<ClothingItem>();

        public JsonFileRepository()
        {
            Load();
        }

        public void Add(ClothingItem item)
        {
            items.Add(item);
            Save();
        }

        public List<ClothingItem> GetAll() => items;

        public bool Remove(string name)
        {
            var item = items.FirstOrDefault(i => i.Name.ToLower() == name.ToLower());
            if (item != null)
            {
                items.Remove(item);
                Save();
                return true;
            }
            return false;
        }

        public List<ClothingItem> SearchByType(string type)
        {
            return items.Where(i => i.Type.ToLower() == type.ToLower()).ToList();
        }

        private void Load()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                items = JsonSerializer.Deserialize<List<ClothingItem>>(json) ?? new List<ClothingItem>();
            }
        }

        private void Save()
        {
            var json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
