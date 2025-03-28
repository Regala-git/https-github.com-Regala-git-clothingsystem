using System;
using System.Collections.Generic; 

namespace ClothingSystem
{
    class Program
    {
        static void Main()
        {
            ClothingStore store = new ClothingStore();
            int userChoice;

            do
            {
                DisplayActions();
                userChoice = GetUserInput(); 

                switch (userChoice)
                {
                    case 1:
                        // Add clothing item
                        Console.Write("Enter Clothing Brand Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Type (Shirt, Pants, Jacket): ");
                        string type = Console.ReadLine();
                        Console.Write("Enter Size (S, M, L, XL): ");
                        string size = Console.ReadLine();
                        Console.Write("Enter Color: ");
                        string color = Console.ReadLine();
                        Console.Write("Enter Price: ");
                        decimal price;
                        if (decimal.TryParse(Console.ReadLine(), out price))
                        {
                            if (store.AddClothing(name, type, size, color, price))
                            {
                                Console.WriteLine("Clothing item added successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Failed to add clothing item. Please check your input.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid price. Please enter a valid decimal number.");
                        }
                        break;

                    case 2:
                        // Display clothing items
                        var items = store.GetClothingItems();
                        if (items.Count == 0)
                        {
                            Console.WriteLine("No clothing items available.");
                        }
                        else
                        {
                            Console.WriteLine("Clothing Inventory:");
                            foreach (var item in items)
                            {
                                item.Display();
                            }
                        }
                        break;

                    case 3:
                        // Remove clothing item
                        Console.Write("Enter the name of the clothing item to remove: ");
                        string itemName = Console.ReadLine();
                        if (store.RemoveClothing(itemName))
                        {
                            Console.WriteLine("Clothing item removed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Item not found.");
                        }
                        break;

                    case 4:
                        // Search by type
                        Console.Write("Enter Clothing Type to Search: ");
                        string searchType = Console.ReadLine();
                        var foundItems = store.SearchByType(searchType);
                        if (foundItems.Count > 0)
                        {
                            Console.WriteLine($"\nClothing items of type: {searchType}");
                            foreach (var item in foundItems)
                            {
                                item.Display();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No items found of this type.");
                        }
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

        static void DisplayActions()
        {
            Console.WriteLine("----- CLOTHING STORE MENU -----");
            Console.WriteLine("[1] Add Clothing Item");
            Console.WriteLine("[2] Display Clothing Items");
            Console.WriteLine("[3] Remove Clothing Item");
            Console.WriteLine("[4] Search by Type");
            Console.WriteLine("[5] Exit");
        }

        static int GetUserInput() // Fixed method definition
        {
            Console.Write("Choose an option: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            Console.WriteLine("Invalid input! Please enter a number.");
            return 0; // Return 0 for invalid input
        }
    }
}