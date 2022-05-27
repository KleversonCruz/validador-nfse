using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Validador.API.Models;

namespace Validador.API.Controllers
{
    public class ValidadorController : Controller
    {

        public IActionResult Index()
        {
            ValidadorModel model = new ValidadorModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ValidadorModel model)
        {
            try
            {
                var validador = Application.CollectionFactory.Create(model.SelectedCollection);
                model.ValidationErrorList = validador.ValidateSchema(model.XmlText);
                return View(model);
            }
            catch (Exception ex)
            {
                model.ExceptionMessage = ex.Message;
                return View(model);
            }
            
        }
    }
}
