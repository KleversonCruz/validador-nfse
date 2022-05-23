//using System.Xml;
//using System.Xml.Linq;
//using System.Xml.Schema;

//namespace ValidadorNFse
//{
//    public class Validator
//    {
//        protected string directoryPath;
//        protected string schemasDirectoryPath;
//        protected XmlSchemaSet schema;
//        public Validator()
//        {
//            directoryPath = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
//            schemasDirectoryPath = directoryPath + "\\Schemas";
//            schema = new();
//        }
//        public void SetSchema(string targetNameSpace, string schemaURI)
//        {
//            schema.Add(targetNameSpace, schemasDirectoryPath + schemaURI);
//        }
//        public void Validate(string xmlPath)
//        {
//            XmlReader rd = XmlReader.Create(directoryPath + xmlPath);
//            XDocument doc = XDocument.Load(rd);
//            doc.Validate(schema, ValidationEventHandler);
//        }

//        private static void ValidationEventHandler(object sender, ValidationEventArgs e)
//        {
//            XmlSeverityType type = XmlSeverityType.Warning;
//            if (Enum.TryParse<XmlSeverityType>("Error", out type))
//            {
//                if (type == XmlSeverityType.Error) throw new Exception(e.Message);
//            }
//        }

//    }
//}
