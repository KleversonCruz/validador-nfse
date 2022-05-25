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
                model.MessageList = validador.ValidateSchema(model.XmlText);
                model.IsValid = false;

                if (model.MessageList.Count == 0)
                {
                    model.MessageList.Add("Validado com sucesso");
                    model.IsValid = true;
                }
                return View(model);
            }
            catch (Exception ex)
            {
                model.MessageList = new List<string>() { ex.Message };
                model.IsValid = false;
                return View(model);
            }
            
        }
    }
}
