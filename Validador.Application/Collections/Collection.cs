using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Validador.Application.Schemas;

namespace Validador.Application
{
    public abstract class Collection
    {
        protected static readonly string DirectoryPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        private string collectionName;

        private readonly List<ValidationError> ValidationErrors = new();
        public string CollectionName { get => collectionName; }
        protected XmlSchemaSet Schemas { get; set; }
        protected string SchemaDirectoryPath
        {
            get
            {
                return Path.Combine(DirectoryPath, "Schemas", this.CollectionName);
            }
        }

        public Collection(string name)
        {
            Schemas = new XmlSchemaSet();
            collectionName = name;
        }

        public List<ValidationError> ValidateSchema(string xmlString)
        {
            SetSchemas();

            XmlReaderSettings settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
                ValidationFlags = XmlSchemaValidationFlags.ProcessInlineSchema | XmlSchemaValidationFlags.ReportValidationWarnings,
                Schemas = Schemas
            };
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);

            XmlReader reader = XmlReader.Create(new StringReader(xmlString), settings);
            while (reader.Read());
            return ValidationErrors;
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                ValidationErrors.Add(new ValidationError(args.Message, ValidationError.Severity.Warning));
            else
                ValidationErrors.Add(new ValidationError(args.Message, ValidationError.Severity.Error));
        }

        protected abstract void SetSchemas();
    }
}
