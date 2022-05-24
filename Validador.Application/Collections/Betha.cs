using System.Xml;

namespace Validador.Application
{
    public class Betha : Collection
    {
        public Betha() : base("Betha") { }

        protected override void SetSchemas()
        {
            Schema.Add(null, Path.Combine(SchemaDirectoryPath, "nfse_v01.xsd"));
            Schema.Add(null, Path.Combine(SchemaDirectoryPath, "xmldsig-core-schema20020212.xsd"));
        }
    }
}
