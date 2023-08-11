using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticalTask.Services.DTO;
using PracticalTask.Services.Interface;

namespace PracticalTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _itemService.GetItems();
            return Ok(items);
        }

        [HttpGet("{srno}")]
        public IActionResult GetItem(int srno)
        {
            var item = _itemService.GetItemById(srno);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateItem(ItemDTO itemDto)
        {
            var srno = _itemService.CreateItem(itemDto);
            return CreatedAtAction(nameof(GetItem), new { srno }, null);
        }

        [HttpPut("{srno}")]
        public IActionResult UpdateItem(int srno, ItemDTO itemDto)
        {
            try
            {
                _itemService.UpdateItem(srno, itemDto);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{srno}")]
        public IActionResult DeleteItem(int srno)
        {
            try
            {
                _itemService.DeleteItem(srno);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
