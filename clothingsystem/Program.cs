using System;
using System.Collections.Generic;
using ClothingSystem.Common;
using ClothingSystem.DataLogic;
using ClothingSystem.BusinessLogic;
using Microsoft.Extensions.Options;

namespace ClothingSystem
{
    internal class Program
    {
        static string[] actions = new string[]
        {
            "[1] Add Item", "[2] View Items", "[3] Remove Item","[4] Search by Type","[5] Exit"
        };

  
        static IClothingDataService dataService = new DbDataService();

        static EmailSettings emailSettings = new EmailSettings
        {
            FromName = "Clothing Store System",
            FromAddress = "yourstoreemail@gmail.com",
            ToName = "Customer",
            ToAddress = "customer@gmail.com",
            SmtpHost = "smtp.gmail.com",
            SmtpPort = 587,
            SmtpUsername = "yourstoreemail@gmail.com",
            SmtpPassword = "your_app_password", 
            EnableTls = true
        };

      
        static Clothingstore store = new Clothingstore(dataService, Options.Create(emailSettings));

        static void Main(string[] args)
        {
            Console.WriteLine("CLOTHING STORE SYSTEM");
            DisplayActions();

            int userChoice = GetUserInput();

            while (userChoice != 5)
            {
                switch (userChoice)
                {
                    case 1:
                        AddItem();
                        break;
                    case 2:
                        ViewItems();
                        break;
                    case 3:
                        RemoveItem();
                        break;
                    case 4:
                        SearchItems();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose between 1 to 5 only.");
                        break;
                }

                DisplayActions();
                userChoice = GetUserInput();
            }

            Console.WriteLine("Exiting program...");
        }

        static void DisplayActions()
        {
            Console.WriteLine("\n----------------------");
            Console.WriteLine("MENU");
            foreach (var action in actions)
            {
                Console.WriteLine(action);
            }
        }

        static int GetUserInput()
        {
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();
            return int.TryParse(input, out int value) ? value : -1;
        }

        static void AddItem()
        {
            Console.WriteLine("\n--- ADD CLOTHING ITEM ---");

            Console.Write("Customer Name: ");
            string name = Console.ReadLine();

            Console.Write("Clothing Type (Shirt, Pants, Jacket, Tops, Dress): ");
            string type = Console.ReadLine();

            Console.Write("Clothing Size (S, M, L, XL): ");
            string size = Console.ReadLine();

            Console.Write("Clothing Color: ");
            string color = Console.ReadLine();

            Console.Write("Customer Email: ");
            string email = Console.ReadLine();

            Console.Write("Ask Price Owner: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            var item = new ClothingItem
            {
                CustomerName = name,
                Type = type,
                Size = size,
                Color = color,
                Email = email,
                Price = price
            };

            bool added = store.AddItem(item);

            if (added)
            {
                Console.WriteLine("Item successfully added. Notification email sent!");
            }
            else
            {
                Console.WriteLine("Item already exists for this customer.");
            }
        }

        static void ViewItems()
        {
            Console.WriteLine("\n--- CLOTHING ITEMS ---");
            var items = store.GetAllItems();

            if (items.Count == 0)
            {
                Console.WriteLine("No items found.");
                return;
            }

            foreach (var item in items)
            {
                item.Display();
            }
        }

        static void RemoveItem()
        {
            Console.Write("\nEnter Customer Name to remove: ");
            string name = Console.ReadLine();

            bool removed = store.RemoveItem(name);

            if (removed)
            {
                Console.WriteLine("Item removed.");
            }
            else
            {
                Console.WriteLine("No item found with that name.");
            }
        }

        static void SearchItems()
        {
            Console.Write("\nEnter clothing type to search: ");
            string type = Console.ReadLine();

            var results = store.SearchByType(type);

            if (results.Count == 0)
            {
                Console.WriteLine("No matching items found.");
                return;
            }

            Console.WriteLine($"Items found for type '{type}':");
            foreach (var item in results)
            {
                item.Display();
            }
        }
    }
}
