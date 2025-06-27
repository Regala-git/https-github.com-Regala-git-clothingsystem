using ClothingSystem.BusinessLogic;
using ClothingSystem.Common;
using Microsoft.AspNetCore.Mvc;

namespace ClothingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingController : Controller
    {
        private readonly Clothingstore store;

        public ClothingController(IClothingDataService repo)
        {
   
            store = new Clothingstore(repo);
        }

        [HttpGet]
        public ActionResult<List<ClothingItem>> GetAll()
        {
            return store.GetAllItems();
        }

        [HttpPost]
        public ActionResult Add(ClothingItem item)
        {
            if (store.AddItem(item))
                return Ok("Item added.");
            return Conflict("Item already exists.");
        }

        [HttpDelete]
        public ActionResult Delete([FromQuery] string customerName)
        {
            if (store.RemoveItem(customerName))
                return Ok("Item removed.");
            return NotFound("Item not found.");
        }

        [HttpGet("search")]
        public ActionResult<List<ClothingItem>> Search([FromQuery] string type)
        {
            return store.SearchByType(type);
        }

        [HttpGet("exists")]
        public ActionResult<bool> Exists([FromQuery] string name)
        {
            return store.Exists(name);
        }
    }
}
