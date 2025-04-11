using System;
using ClothingSystem.BusinessLogic;
using ClothingSystem.Common;
using System.Collections.Generic;

namespace ClothingSystem
{
    class Program
    {
        static void Main()
        {
            ClothingService service = new ClothingService();
            int choice;

            do
            {
                ShowMenu();
                choice = GetChoice();

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Type: (Shirt, Pants, Jacket): ");
                        string type = Console.ReadLine();
                        Console.Write("Enter Size (S, M, L, XL): "); 
                        string size = Console.ReadLine();
                        Console.Write("Enter Color: ");
                        string color = Console.ReadLine();
                        Console.Write("Enter Price: ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        service.AddClothing(name, type, size, color, price);
                        Console.WriteLine("Clothing item added.");
                        break;

                    case 2:
                        List<ClothingItem> items = service.GetClothingItems();
                        if (items.Count == 0)
                        {
                            Console.WriteLine("No items to show.");
                        }
                        else
                        {
                            foreach (var item in items)
                            {
                                item.Display();
                            }
                        }
                        break;

                    case 3:
                        Console.Write("Enter name to remove: ");
                        string removeName = Console.ReadLine();
                        if (service.RemoveClothing(removeName))
                            Console.WriteLine("Item removed.");
                        else
                            Console.WriteLine("Item not found.");
                        break;

                    case 4:
                        Console.Write("Enter type to search: ");
                        string searchType = Console.ReadLine();
                        var found = service.SearchByType(searchType);
                        if (found.Count == 0)
                        {
                            Console.WriteLine("No items found.");
                        }
                        else
                        {
                            foreach (var item in found)
                            {
                                item.Display();
                            }
                        }
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
            Console.WriteLine("\n-- CLOTHING STORE MENU --");
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
    }
}
