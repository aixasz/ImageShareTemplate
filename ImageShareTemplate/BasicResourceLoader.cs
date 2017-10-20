namespace ImageShareTemplate
{
    public class BasicResourceLoader : IResourceLoader
    {
        private static BasicResourceLoader _instance;

        public static BasicResourceLoader Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BasicResourceLoader();
                return _instance;
            }
        }

        public byte[] Load(string src)
        {
            var sourceType = GetSourceType(src);
            return sourceType == SourceType.Url
                ? FileHelpers.LoadImageFromUrl(src)
                : FileHelpers.LoadImageFormPath(src);
        }

        public SourceType GetSourceType(string src)
        {
            return src.StartsWith("http://") || src.StartsWith("https://") ? SourceType.Url : SourceType.Path;
        }
    }
}