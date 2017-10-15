using System;
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
            Stream stream = null;
            byte[] result;

            try
            {
                var webProxy = new WebProxy();
                var request = (HttpWebRequest)WebRequest.Create(url);

                var response = (HttpWebResponse)request.GetResponse();
                stream = response.GetResponseStream();

                using (var binaryReader = new BinaryReader(stream))
                {
                    var contentLenght = (int)(response.ContentLength);
                    result = binaryReader.ReadBytes(contentLenght);
                }

                stream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                result = null;
            }

            return result;
        }
    }
}
