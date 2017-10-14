using System.IO;
using System.Net;

namespace ImageShareTemplate
{
    public class BlockImage : Block, IBlockImage
    {
        public byte[] Data { get; }

        public BlockImage(string src, SourceType sourceType)
        {
            Data = sourceType == SourceType.Url
                ? LoadImageFromUrl(src)
                : LoadImageFormPath(src);
        }

        private byte[] LoadImageFormPath(string src)
        {
            return File.ReadAllBytes(src);
        }

        private byte[] LoadImageFromUrl(string src)
        {
            var webClient = new WebClient();
            return webClient.DownloadData(src);
        }
    }
}
