using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidadorNFse.Validator
{
    public static class Factory
    {
        public static Collection Create(ECollections collection)
        {
            return Create(collection.ToString());
        }

        public static Collection Create(string collection)
        {
            switch (collection)
            {
                default:

                case "Abrasf":
                    return new Abrasf();
                case "Ginfes":
                    return new Ginfes();
                case "Betha":
                    return new Betha();
            }
        }
    }
}
