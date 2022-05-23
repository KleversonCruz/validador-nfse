using Microsoft.AspNetCore.Mvc;
using Validador.API.Models;

namespace Validador.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidadorController : ControllerBase
    {
        [HttpPost]
        public IActionResult Validate([FromForm] ValidadorModel model)
        {
            var validador = Application.Factory.Create(model.CollectionName);
            var errorList =validador.ValidateSchema(model.XmlText);
            if (errorList.Count > 0)
            {
                return BadRequest(errorList);
            }
            return Ok();
        }
    }
}
