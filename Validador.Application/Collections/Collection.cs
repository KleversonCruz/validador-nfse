using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Validador.Application
{
    public abstract class Collection
    {
        protected static readonly string DirectoryPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        private string collectionName;

        private readonly List<string> ValidationErrors = new();
        public string CollectionName { get => collectionName; }
        protected XmlSchemaSet Schema { get; set; }
        protected string SchemaDirectoryPath
        {
            get
            {
                return Path.Combine(DirectoryPath, "Schemas", this.CollectionName);
            }
        }

        public Collection(string name)
        {
            Schema = new XmlSchemaSet();
            collectionName = name;
        }

        public List<string> ValidateSchema(string xmlString)
        {
            SetSchemas();
            XmlReader reader = XmlReader.Create(new StringReader(xmlString));
            XDocument document = XDocument.Load(reader);
            document.Validate(Schema, ValidationEventHandler);
            return ValidationErrors;
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            ValidationErrors.Add(ErrorHandler.GetMessage(e.Message));
        }

        protected abstract void SetSchemas();
    }
}
