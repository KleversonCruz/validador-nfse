using Microsoft.AspNetCore.Mvc.Rendering;

namespace Validador.API.Models
{
    public class ValidadorModel
    {
        public ValidadorModel()
        {
            CollectionList = new SelectList(GetCollectionSelect(), "Value", "Text");
            XmlText = string.Empty;
            SelectedCollection = string.Empty;
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

        public List<string> MessageList = new();
        public bool IsValid { get; set; }
    }
}
