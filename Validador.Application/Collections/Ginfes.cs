namespace Validador.Application
{
    public class Ginfes : Collection
    {
        public Ginfes() : base("Ginfes") { }

        protected override void SetSchemas()
        {
            Schemas.Add(null, Path.Combine(SchemaDirectoryPath, "tipos_v03.xsd"));
            Schemas.Add(null, Path.Combine(SchemaDirectoryPath, "cabecalho_v03.xsd"));
            Schemas.Add(null, Path.Combine(SchemaDirectoryPath, "servico_enviar_lote_rps_envio_v03.xsd"));
            Schemas.Add(null, Path.Combine(SchemaDirectoryPath, "servico_consultar_situacao_lote_rps_envio_v03.xsd"));
            Schemas.Add(null, Path.Combine(SchemaDirectoryPath, "xmldsig-core-schema20020212_v03.xsd"));
        }
    }
}
