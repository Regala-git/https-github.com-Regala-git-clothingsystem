using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClothingSystem.Common;

namespace ClothingSystem.DataLogic
{
    public class TextFileDataService : IClothingDataService
    {
        private readonly string filePath = "clothingitems.txt";
        private const char Separator = '|';

        private ClothingItem ParseLine(string line)
        {
            var parts = line.Split(Separator);
            return new ClothingItem
            {
                CustomerName = parts[0],
                Type = parts[1],
                Size = parts[2],
                Color = parts[3],
                Price = decimal.Parse(parts[4])
            };
        }

        private string ToLine(ClothingItem item)
        {
            return $"{item.CustomerName}{Separator}{item.Type}{Separator}{item.Size}{Separator}{item.Color}{Separator}{item.Price}";
        }

        public void AddItem(ClothingItem item)
        {
            File.AppendAllLines(filePath, new[] { ToLine(item) });
        }

        public List<ClothingItem> GetAllItems()
        {
            if (!File.Exists(filePath)) return new List<ClothingItem>();
            return File.ReadAllLines(filePath).Select(ParseLine).ToList();
        }

        public List<ClothingItem> SearchByType(string type)
        {
            return GetAllItems().FindAll(i => i.Type == type);
        }

        public bool RemoveItem(string customerName)
        {
            var items = GetAllItems();
            var item = items.FirstOrDefault(i => i.CustomerName == customerName);
            if (item != null)
            {
                items.Remove(item);
                File.WriteAllLines(filePath, items.Select(ToLine));
                return true;
            }
            return false;
        }

        public bool Exists(string customerName)
        {
            return GetAllItems().Any(i => i.CustomerName == customerName);
        }
    }
}
