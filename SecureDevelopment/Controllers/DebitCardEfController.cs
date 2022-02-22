using Microsoft.AspNetCore.Mvc;
using SecureDevelopment.Repository;

namespace SecureDevelopment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DebitCardEfController : Controller
    {
        private readonly IRepositoryCardEf _repositoryCardEf;

        public DebitCardEfController(IRepositoryCardEf repositoryCardEf)
        {
            _repositoryCardEf = repositoryCardEf;
        }
        
        [HttpPost("AddCard")]
        public IActionResult AddCard([FromBody] DebitCard newCard)
        {
            var result = _repositoryCardEf.Create(newCard);
            return Ok(result);
        }
        
        [HttpGet("GetAllCards")]
        public IActionResult GetCards()
        {
            var result = _repositoryCardEf.Read();
            return Ok(result);
        }
        
        [HttpGet("GetCardForId")]
        public IActionResult GetCardForId([FromQuery] int id)
        {
            var result = _repositoryCardEf.Read(id);
            return Ok(result);
        }

        [HttpPut("UpdateCard")]
        public IActionResult UpdateCard([FromBody] DebitCard updateCard)
        {
            var result = _repositoryCardEf.Update(updateCard);
            return Ok(result);
        }

        [HttpDelete("DeleteCard")]
        public IActionResult DeleteCard([FromQuery] int idCard)
        {
            var result = _repositoryCardEf.Delete(idCard);
            return Ok(result);
        }
    }
}