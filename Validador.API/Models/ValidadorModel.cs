using Microsoft.AspNetCore.Mvc.Rendering;
using Validador.Application.Schemas;

namespace Validador.API.Models
{
    public class ValidadorModel
    {
        public ValidadorModel()
        {
            CollectionList = new SelectList(GetCollectionSelect(), "Value", "Text");
            XmlText = string.Empty;
            SelectedCollection = string.Empty;
            ExceptionMessage = string.Empty;
        }

        public List<SelectListItem> GetCollectionSelect()
        {
            var collectionList = Enum.GetValues(typeof(Application.ECollections)).Cast<Application.ECollections>().ToList();
            List<SelectListItem> selectList = new();
            foreach (var item in collectionList)
            {
                selectList.Add(new SelectListItem { Value = item.ToString(), Text = item.ToString() });
            }
            return selectList;
        }

        public string XmlText { get; set; }
        public string SelectedCollection { get; set; }
        public SelectList CollectionList { get; set; }

        public List<ValidationError> ValidationErrorList = new();
        public bool IsValid { get { return ValidationErrorList.Count == 0 & XmlText != string.Empty & ExceptionMessage == string.Empty; } }
        public string ExceptionMessage { get; set; }
    }
}
