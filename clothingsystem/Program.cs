using System;
using ClothingSystem.BusinessLogic;
using ClothingSystem.Common;
using ClothingSystem.DataLogic;
using System.Collections.Generic;

namespace ClothingSystem
{
    class Program
    {
        static void Main()
        {
            IClothingRepository repo = new TextFileRepository();
            ClothingService service = new ClothingService(repo);
            int choice;

            do
            {
                ShowMenu();
                choice = GetChoice();

                switch (choice)
                {
                    case 1:
                        AddItem(service);
                        break;
                    case 2:
                        DisplayItems(service);
                        break;
                    case 3:
                        RemoveItem(service);
                        break;
                    case 4:
                        SearchItems(service);
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

            } while (choice != 5);
        }

 

        static void ShowMenu()
        {
            Console.WriteLine("-- CLOTHING STORE MENU --");
            Console.WriteLine("[1] Add Item");
            Console.WriteLine("[2] Display Items");
            Console.WriteLine("[3] Remove Item");
            Console.WriteLine("[4] Search by Type");
            Console.WriteLine("[5] Exit");
        }

        static int GetChoice()
        {
            Console.Write("Choose: ");
            int.TryParse(Console.ReadLine(), out int choice);
            return choice;
        }

        static void AddItem(ClothingService service)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Type (Shirt, Pants, Jacket): ");
            string type = Console.ReadLine();
            Console.Write("Enter Size (S, M, L, XL): ");
            string size = Console.ReadLine();
            Console.Write("Enter Color: ");
            string color = Console.ReadLine();
            Console.Write("Enter Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            service.AddClothing(name, type, size, color, price);
            Console.WriteLine("Clothing item added.");
        }

        static void DisplayItems(ClothingService service)
        {
            var items = service.GetClothingItems();
            if (items.Count == 0)
            {
                Console.WriteLine("No items to show.");
                return;
            }

            foreach (var item in items)
            {
                item.Display();
            }
        }

        static void RemoveItem(ClothingService service)
        {
            Console.Write("Enter name to remove: ");
            string name = Console.ReadLine();
            if (service.RemoveClothing(name))
                Console.WriteLine("Item removed.");
            else
                Console.WriteLine("Item not found.");
        }

        static void SearchItems(ClothingService service)
        {
            Console.Write("Enter type to search: ");
            string type = Console.ReadLine();
            var results = service.SearchByType(type);

            if (results.Count == 0)
            {
                Console.WriteLine("No items found.");
                return;
            }

            foreach (var item in results)
            {
                item.Display();
            }
        }
    }
}
