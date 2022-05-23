using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Validador.Application
{
    public abstract class Collection
    {
        private static readonly string DirectoryPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        public string CollectionName { get; set; }
        public XmlSchemaSet Schema { get; set; }
        public string SchemaDirectoryPath
        {
            get
            {
                return Path.Combine(DirectoryPath, "Schemas", this.CollectionName);
            }
        }

        public Collection()
        {
            Schema = new XmlSchemaSet();
            CollectionName = "Abrasf";
        }

        private readonly List<string> ValidationErrors = new();

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
            ValidationErrors.Add(e.Message);
        }

        public abstract void SetSchemas();
    }
}
