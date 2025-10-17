using ClothingSystem.Common;
using ClothingSystem.DataLogic;
using System.Collections.Generic;

namespace ClothingSystem.BusinessLogic
{
    public class Clothingstore
    {
        private readonly IClothingDataService repo;
        private readonly EmailService emailService;

       
        public Clothingstore(IClothingDataService repository)
        {
            repo = repository;
            emailService = new EmailService();
        }

        public bool AddItem(ClothingItem item)
        {
            if (!repo.Exists(item.CustomerName))
            {
                repo.AddItem(item);

                string subject = "Clothing Item Added";
                string message = $"Dear {item.CustomerName},\n\nYour item ({item.Type}, {item.Color}, {item.Size}) " +
                                 $"has been successfully added to the Clothing Store System.\n\nThank you!";

                bool emailSent = emailService.SendNotification(item.Email, subject, message);

                return emailSent; 
            }
            return false;
        }

        public bool RemoveItem(string customerName)
        {
            return repo.RemoveItem(customerName);
        }

        public List<ClothingItem> GetAllItems()
        {
            return repo.GetAllItems();
        }

        public List<ClothingItem> SearchByType(string type)
        {
            return repo.SearchByType(type);
        }

        public bool Exists(string customerName)
        {
            return repo.Exists(customerName);
        }
    }
}
