using System.Threading.Tasks;
using CardDetailsGetter.Data;
using Microsoft.AspNetCore.Mvc;

namespace CardDetailsGetter.Controllers
{
    [Route("api/[controller]")]
    public class CardDetailsController : ControllerBase
    {
        private readonly ICardDetailsRepository _repo;
        public CardDetailsController(ICardDetailsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{number}")]
        public IActionResult GetCardDetails(string number)
        {
            var cardDetails = _repo.GetCardDetails(number);

            if(cardDetails != null) {
                return Ok(cardDetails);
            }

            return BadRequest("Card details not found");
        }

        [HttpPost("{number}")]
        public async Task<IActionResult> GetCardDetailsAsync(string number)
        {
            var cardDetails = await _repo.GetCardDetailsAsync(number);

            if(cardDetails != null) {
                return Ok(cardDetails);
            }

            return BadRequest("Card details not found");
        }
    }
}