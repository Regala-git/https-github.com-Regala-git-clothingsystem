using System;
using ClothingSystem.Common;
using ClothingSystem.DataLogic;
using System.Collections.Generic;

namespace ClothingSystem
{
    class Program
    {
        static void Main()
        {
            IClothingRepository repo = new JsonFileRepository();
            Clothingstore store = new Clothingstore(repo);
            int choice;

            do
            {
                ShowMenu();
                choice = GetChoice();

                switch (choice)
                {
                    case 1:
                        AddItem(store);
                        break;
                    case 2:
                        DisplayItems(store);
                        break;
                    case 3:
                        RemoveItem(store);
                        break;
                    case 4:
                        SearchItems(store);
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

        static void AddItem(Clothingstore store)
        {
            Console.Write("Enter Customer Name: ");
            string CustomerName = Console.ReadLine();
            Console.Write("Enter Your Type Clothing: (Shirt, Pants, Jacket, Tops): ");
            string type = Console.ReadLine();
            Console.Write("Enter Size :(S, M, L, XL): ");
            string size = Console.ReadLine();
            Console.Write("Enter the Color you Want: ");
            string color = Console.ReadLine();
            Console.Write("Enter Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            store.AddClothing(CustomerName, type, size, color, price);
            Console.WriteLine("Clothing item added.");
        }

        static void DisplayItems(Clothingstore store)
        {
            var items = store.GetClothingItems();
            if (items.Count == 0)
            {
                Console.WriteLine("No items to show.");
                return;
            }

            foreach (var item in items)

                store.DisplayItems(items);
        }
    

        static void RemoveItem(Clothingstore store)
        {
            Console.Write("Enter name to remove: ");
            string name = Console.ReadLine();
            if (store.RemoveClothing(name))
                Console.WriteLine("Item removed.");
            else
                Console.WriteLine("Item not found.");
        }

        static void SearchItems(Clothingstore store)
        {
            Console.Write("Enter type to search: ");
            string type = Console.ReadLine();
            var results = store.SearchByType(type);

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
