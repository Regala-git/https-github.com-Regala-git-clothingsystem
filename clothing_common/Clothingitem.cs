namespace ClothingSystem.Common
{
    public class ClothingItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }

        public void Display()
        {
            System.Console.WriteLine($"{Name} - {Type}, Size: {Size}, Color: {Color}, Price: ₱{Price}");
        }
    }
}

