using System;

namespace ClothingSystem.Common
{
    public class ClothingItem
    {
        public string CustomerName { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string Email { get; set; } 

        public void Display()
        {
            Console.WriteLine(
                $"Name: {CustomerName}, Email: {Email}, Type: {Type}, Size: {Size}, Color: {Color}, Price: {Price:C}"
            );
        }
    }
}
