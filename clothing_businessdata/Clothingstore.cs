using System;
using System.Collections.Generic;

namespace ClothingSystem
{
    public class ClothingStore
    {
        private List<ClothingItem> inventory = new List<ClothingItem>();

        // Adds clothing item to inventory
        public bool AddClothing(string name, string type, string size, string color, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(type) ||
                string.IsNullOrWhiteSpace(size) || string.IsNullOrWhiteSpace(color) || price <= 0)
            {
                return false; // Invalid input
            }

            inventory.Add(new ClothingItem(name, type, size, color, price));
            return true; // Successfully added
        }

        // Returns a list of all clothing items
        public List<ClothingItem> GetClothingItems()
        {
            return inventory;
        }

        // Removes a clothing item by name
        public bool RemoveClothing(string name)
        {
            ClothingItem itemToRemove = inventory.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (itemToRemove != null)
            {
                inventory.Remove(itemToRemove);
                return true;
            }
            return false;
        }

        // Searches for clothing items by type
        public List<ClothingItem> SearchByType(string type)
        {
            return inventory.FindAll(item => item.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
        }

        // Public class for ClothingItem
        public class ClothingItem 
        {
            public string Name { get; }
            public string Type { get; }
            public string Size { get; }
            public string Color { get; }
            public decimal Price { get; }

            public ClothingItem(string name, string type, string size, string color, decimal price)
            {
                Name = name;
                Type = type;
                Size = size;
                Color = color;
                Price = price;
            }

            public void Display()
            {
                Console.WriteLine($"{Name} - {Type}, Size: {Size}, Color: {Color}, Price: ${Price}");
            }
        }
    }
}