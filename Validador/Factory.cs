namespace Validador.Application
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
                    return new Abrasf();
                case "Ginfes":
                    return new Ginfes();
                case "Betha":
                    return new Betha();
            }
        }
    }
}