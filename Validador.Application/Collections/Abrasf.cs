namespace Validador.Application
{
    public class Abrasf : Collection
    {
        public Abrasf() : base("Abrasf") { }

        protected override void SetSchemas()
        {
            Schemas.Add(null, Path.Combine(SchemaDirectoryPath, "nfse_v2-03 2016.xsd"));
            Schemas.Add(null, Path.Combine(SchemaDirectoryPath, "xmldsig-core-schema20020212.xsd"));
        }
    }
}
