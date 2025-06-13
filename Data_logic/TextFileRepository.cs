using System;
using System.Collections.Generic;
using System.IO;
using ClothingSystem.Common;

namespace ClothingSystem.DataLogic
{
    public class TextFileRepository : IClothingRepository
    {
        private readonly string filePath = "clothing.txt";

        public void AddItem(ClothingItem item)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{item.CustomerName}|{item.Type}|{item.Size}|{item.Color}|{item.Price}");
            }
        }

        public List<ClothingItem> GetAllItems()
        {
            var items = new List<ClothingItem>();
            if (!File.Exists(filePath)) return items;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length == 5)
                {
                    items.Add(new ClothingItem
                    {
                        CustomerName = parts[0],
                        Type = parts[1],
                        Size = parts[2],
                        Color = parts[3],
                        Price = decimal.TryParse(parts[4], out decimal price) ? price : 0
                    });
                }
            }

            return items;
        }

        public bool RemoveItem(string customerName)
        {
            var items = GetAllItems();
            var item = items.Find(i => i.CustomerName.Equals(customerName, StringComparison.OrdinalIgnoreCase));
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
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var item in items)
                {
                    writer.WriteLine($"{item.CustomerName}|{item.Type}|{item.Size}|{item.Color}|{item.Price}");
                }
            }
        }
    }
}

