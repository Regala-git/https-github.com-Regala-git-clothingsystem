using System;

namespace ClothingSystem
{
    class ClothingItem
    {
        public string Name { get; set; }
        public string Type { get; set; } // Shirt, Pants, Jacket, etc.
        public string Size { get; set; } // S, M, L, XL
        public string Color { get; set; }
        public decimal Price { get; set; }

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

    class ClothingStore
    {
        private List<ClothingItem> inventory = new List<ClothingItem>();

        public void DisplayActions()
        {
            Console.WriteLine("\n----- CLOTHING STORE MENU -----");
            Console.WriteLine("[1] Add Clothing Item");
            Console.WriteLine("[2] Display Clothing Items");
            Console.WriteLine("[3] Remove Clothing Item");
            Console.WriteLine("[4] Search by Type");
            Console.WriteLine("[5] Exit");
        }

        public int GetUserInput()
        {
            Console.Write("Choose an option: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void AddClothing()
        {
            Console.Write("Enter Clothing Brand Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Type (Shirt, Pants, Jacket,): ");
            string type = Console.ReadLine();
            Console.Write("Enter Size (S, M, L, XL): ");
            string size = Console.ReadLine();
            Console.Write("Enter Color: ");
            string color = Console.ReadLine();
            Console.Write("Enter Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            inventory.Add(new ClothingItem(name, type, size, color, price));
            Console.WriteLine("Clothing item added successfully!");
        }

        public void DisplayClothing()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("No clothing items available.");
                return;
            }

            Console.WriteLine("Clothing Inventory:");
            foreach (var item in inventory)
            {
                item.Display();
            }
        }

        public void RemoveClothing()
        {
            Console.Write("Enter the name of the clothing item to remove: ");
            string name = Console.ReadLine();

            ClothingItem itemToRemove = inventory.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (itemToRemove != null)
            {
                inventory.Remove(itemToRemove);
                Console.WriteLine("Clothing item removed successfully!");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        public void SearchByType()
        {
            Console.Write("Enter Clothing Type to Search: ");
            string type = Console.ReadLine();

            List<ClothingItem> foundItems = inventory.FindAll(item => item.Type.Equals(type, StringComparison.OrdinalIgnoreCase));

            if (foundItems.Count > 0)
            {
                Console.WriteLine($"Clothing items of type: {type}");
                foreach (var item in foundItems)
                {
                    item.Display();
                }
            }
            else
            {
                Console.WriteLine("No items found of this type.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            ClothingStore store = new ClothingStore();
            int userChoice;

            do
            {
                store.DisplayActions();
                userChoice = store.GetUserInput();

                switch (userChoice)
                {
                    case 1:
                        store.AddClothing();
                        break;
                    case 2:
                        store.DisplayClothing();
                        break;
                    case 3:
                        store.RemoveClothing();
                        break;
                    case 4:
                        store.SearchByType();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }

            } while (userChoice != 5);
        }
    }
}
