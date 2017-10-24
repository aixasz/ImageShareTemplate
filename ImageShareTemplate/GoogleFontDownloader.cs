using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using SixLabors.Fonts;

namespace ImageShareTemplate
{
    public class GoogleFontDownloader : IFontProvider
    {
        private readonly string UserAgent = "Mozilla/5.0 (X11; Linux i686; rv:6.0) Gecko/20100101 Firefox/6.0";

        public Font GetFont(string family, int size)
        {
            var fontPath = DownloadFontToTempFolder(family);

            var collection = new FontCollection();

            var fontFamily = collection.Install(fontPath);

            return fontFamily.CreateFont(size);
        }

        public string DownloadFontToTempFolder(string fontFamily)
        {
            var webClient = new WebClient();
            webClient.Headers.Add("user-agent", UserAgent);

            var url = $"http://fonts.googleapis.com/css?family={Uri.EscapeUriString(fontFamily)}";

            var css = webClient.DownloadString(url);

            var urlMatches = Regex.Matches(css, "url\\(([^\\)]+)\\)");

            var tempFolderPath = Path.Combine(Path.GetTempPath(), "fontCache");

            Directory.CreateDirectory(tempFolderPath);

            if (urlMatches.Any())
            {
                var first = urlMatches.First();

                var fontUri = new Uri(first.Groups[1].Value);

                var localFontPath = Path.Combine(tempFolderPath, Path.GetFileName(fontUri.LocalPath));

                if (!File.Exists(localFontPath))
                    webClient.DownloadFile(fontUri, localFontPath);

                return localFontPath;
            }

            throw new Exception("Font not found " + fontFamily);
        }
    }
}