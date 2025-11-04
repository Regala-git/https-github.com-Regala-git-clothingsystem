using ClothingSystem.BusinessLogic;
using ClothingSystem.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace ClothingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingController : ControllerBase
    {
        private readonly Clothingstore store;
        private readonly EmailService emailService;

        public ClothingController(IClothingDataService repo, IOptions<EmailSettings> emailSettings)
        {
            store = new Clothingstore(repo, emailSettings);
            emailService = new EmailService(emailSettings);
        }

        
        [HttpGet]
        public ActionResult<List<ClothingItem>> GetAll()
        {
            var items = store.GetAllItems();
            emailService.SendEmail("Admin viewed all items");

            return items;
        }

        [HttpPost]
        public ActionResult Add(ClothingItem item)
        {
            if (store.AddItem(item))
            {
               
                emailService.SendEmail(item.CustomerName);
                return Ok("Item added successfully and email sent.");
            }

            return Conflict("Item already exists.");
        }


        [HttpDelete]
        public ActionResult Delete([FromQuery] string customerName)
        {
            if (store.RemoveItem(customerName))
            {
                emailService.SendEmail(customerName);
                return Ok("Item removed and email sent.");
            }

            return NotFound("Item not found.");
        }

      
        [HttpGet("search")]
        public ActionResult<List<ClothingItem>> Search([FromQuery] string type)
        {
            var results = store.SearchByType(type);
            emailService.SendEmail($"A search was made for type: {type}");
            return results;
        }

        [HttpGet("exists")]
        public ActionResult<bool> Exists([FromQuery] string name)
        {
            bool found = store.Exists(name);
            emailService.SendEmail($"Checked if {name} exists in the database.");
            return found;
        }
    }
}
