namespace ImageShareTemplate
{
    public class BlockImage : Block, IBlockImage
    {
        public BlockImage(string src) : this(src, BasicResourceLoader.Instance)
        {
        }

        public BlockImage(string src, IResourceLoader loader)
        {
            Data = loader.Load(src);
        }

        public BlockImage(byte[] data)
        {
            Data = data;
        }

        public byte[] Data { get; }
    }
}