namespace ImageShareTemplate
{
    public class BlockImage : Block, IBlockImage
    {
        public byte[] Data { get; }

        public BlockImage(string src)
        {
            var sourceType = GetSourceType(src);
            Data = sourceType == SourceType.Url
                ? FileHelpers.LoadImageFromUrl(src)
                : FileHelpers.LoadImageFormPath(src);
        }

        private SourceType GetSourceType(string src)
        {
            return src.Contains("http") ? SourceType.Url : SourceType.Path;
        }
    }
}
