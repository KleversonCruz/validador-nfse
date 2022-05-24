﻿using System.Xml;

namespace Validador.Application
{
    public class Betha20 : Collection
    {
        public Betha20()
        {
            CollectionName = "Betha20";
        }

        public override void SetSchemas()
        {
            Schema.Add(null, Path.Combine(SchemaDirectoryPath, "nfse_v202.xsd"));
            Schema.Add(null, Path.Combine(SchemaDirectoryPath, "xmldsig-core-schema20020212.xsd"));
        }
    }
}
