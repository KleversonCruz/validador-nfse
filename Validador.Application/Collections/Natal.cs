namespace Validador.Application
{
    public class Natal : Collection
    {
        public Natal() : base("Natal") { }

        protected override void SetSchemas()
        {
            Schemas.Add(null, Path.Combine(SchemaDirectoryPath, "nfse.xsd"));
            Schemas.Add(null, Path.Combine(SchemaDirectoryPath, "xmldsig-core-schema20020212.xsd"));
        }
    }
}
