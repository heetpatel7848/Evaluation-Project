using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticalTask.Services.DTO;
using PracticalTask.Services.Interface;

namespace PracticalTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceChangeController : ControllerBase
    {
        private readonly IPriceChangeService _priceChangeService;

        public PriceChangeController(IPriceChangeService priceChangeService)
        {
            _priceChangeService = priceChangeService;
        }

        [HttpGet]
        public IActionResult GetPriceChanges()
        {
            var priceChanges = _priceChangeService.GetPriceChanges();
            return Ok(priceChanges);
        }

        [HttpGet("{srno}")]
        public IActionResult GetPriceChange(int srno)
        {
            var priceChange = _priceChangeService.GetPriceChangeById(srno);
            if (priceChange == null)
            {
                return NotFound();
            }
            return Ok(priceChange);
        }

        [HttpPost]
        public IActionResult CreatePriceChange(PriceChangeDTO priceChangeDto)
        {
            var srno = _priceChangeService.CreatePriceChange(priceChangeDto);
            return CreatedAtAction(nameof(GetPriceChange), new { srno }, null);
        }

        [HttpPut("{srno}")]
        public IActionResult UpdatePriceChange(int srno, PriceChangeDTO priceChangeDto)
        {
            try
            {
                _priceChangeService.UpdatePriceChange(srno, priceChangeDto);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{srno}")]
        public IActionResult DeletePriceChange(int srno)
        {
            try
            {
                _priceChangeService.DeletePriceChange(srno);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }


}
