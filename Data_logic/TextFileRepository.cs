using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClothingSystem.Common;

namespace ClothingSystem.DataLogic
{
    public class TextFileRepository : IClothingRepository
    {
        private string filePath = "clothing.txt";
        private List<ClothingItem> items = new List<ClothingItem>();

        public TextFileRepository()
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
            if (!File.Exists(filePath)) return;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 5 && decimal.TryParse(parts[4], out decimal price))
                {
                    items.Add(new ClothingItem
                    {
                        Name = parts[0],
                        Type = parts[1],
                        Size = parts[2],
                        Color = parts[3],
                        Price = price
                    });
                }
            }
        }

        private void Save()
        {
            var lines = items.Select(i => $"{i.Name},{i.Type},{i.Size},{i.Color},{i.Price}");
            File.WriteAllLines(filePath, lines);
        }
    }
}
