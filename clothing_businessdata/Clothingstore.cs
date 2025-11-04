using ClothingSystem.Common;
using ClothingSystem.DataLogic;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace ClothingSystem.BusinessLogic
{
    public class Clothingstore
    {
        private readonly IClothingDataService repo;
        private readonly EmailService emailService;

        public Clothingstore(IClothingDataService repository, IOptions<EmailSettings> emailSettings)
        {
            repo = repository;
            emailService = new EmailService(emailSettings);
        }

        public bool AddItem(ClothingItem item)
        {
            if (!repo.Exists(item.CustomerName))
            {
                repo.AddItem(item);

                // Send email notification
                emailService.SendEmail(item.CustomerName);

                return true;
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
