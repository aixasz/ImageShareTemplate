using System.IO;
using SixLabors.ImageSharp;
using System.Net;

namespace ImageShareTemplate
{
    public class BlockImage : IBlockImage
    {
        public Rgba32 BackgroundColor { get; set; } = Rgba32.Transparent;

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
