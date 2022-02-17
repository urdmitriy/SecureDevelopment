using Microsoft.AspNetCore.Mvc;
using SecureDevelopment.Repository;

namespace SecureDevelopment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DebitCardDapperController : Controller
    {
        private readonly IRepositoryCardDapper _repositoryCardDapper;

        public DebitCardDapperController(IRepositoryCardDapper repositoryCardDapper)
        {
            _repositoryCardDapper = repositoryCardDapper;
        }
        
        [HttpPost("AddCard")]
        public IActionResult AddCard([FromBody] DebitCard newCard)
        {
            var result = _repositoryCardDapper.Create(newCard);
            return Ok(result);
        }
        
        [HttpGet("GetAllCards")]
        public IActionResult GetCards()
        {
            var result = _repositoryCardDapper.Read();
            return Ok(result);
        }
        
        [HttpGet("GetCardForId")]
        public IActionResult GetCardForId([FromQuery] int id)
        {
            var result = _repositoryCardDapper.Read(id);
            return Ok(result);
        }

        [HttpPut("UpdateCard")]
        public IActionResult UpdateCard([FromBody] DebitCard updateCard)
        {
            var result = _repositoryCardDapper.Update(updateCard);
            return Ok(result);
        }

        [HttpDelete("DeleteCard")]
        public IActionResult DeleteCard([FromQuery] int idCard)
        {
            var result = _repositoryCardDapper.Delete(idCard);
            return Ok(result);
        }
    }
}