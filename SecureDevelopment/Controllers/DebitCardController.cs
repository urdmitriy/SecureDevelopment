using Microsoft.AspNetCore.Mvc;
using SecureDevelopment.Repository;

namespace SecureDevelopment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DebitCardController : Controller
    {
        private readonly IRepositoryCard _repositoryCard;

        public DebitCardController(IRepositoryCard repositoryCard)
        {
            _repositoryCard = repositoryCard;
        }
        
        [HttpPost("AddCard")]
        public IActionResult AddCard([FromBody] DebitCard newCard)
        {
            var result = _repositoryCard.Create(newCard);
            return Ok(result);
        }
        
        [HttpGet("GetAllCards")]
        public IActionResult GetCards()
        {
            var result = _repositoryCard.Read();
            return Ok(result);
        }
        
        [HttpGet("GetCardForId")]
        public IActionResult GetCardForId([FromQuery] int id)
        {
            var result = _repositoryCard.Read(id);
            return Ok(result);
        }

        [HttpPut("UpdateCard")]
        public IActionResult UpdateCard([FromBody] DebitCard updateCard)
        {
            var result = _repositoryCard.Update(updateCard);
            return Ok(result);
        }

        [HttpDelete("DeleteCard")]
        public IActionResult DeleteCard([FromQuery] int idCard)
        {
            var result = _repositoryCard.Delete(idCard);
            return Ok(result);
        }
    }
}