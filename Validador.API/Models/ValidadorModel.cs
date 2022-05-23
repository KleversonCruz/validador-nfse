using System.ComponentModel.DataAnnotations;

namespace Validador.API.Models
{
    public class ValidadorModel
    {
        [Required]
        public string CollectionName { get; set; }
        [Required]
        public string XmlText { get; set; }
    }
}
