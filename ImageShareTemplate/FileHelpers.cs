using System.IO;
using System.Net;

namespace ImageShareTemplate
{
    public static class FileHelpers
    {
        public static byte[] LoadImageFormPath(string src)
        {
            return File.ReadAllBytes(src);
        }

        public static byte[] LoadImageFromUrl(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);

                using (var response = (HttpWebResponse) request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var binaryReader = new BinaryReader(stream))
                        {
                            var contentLenght = (int)response.ContentLength;
                            return binaryReader.ReadBytes(contentLenght);
                        }
                    }    
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
