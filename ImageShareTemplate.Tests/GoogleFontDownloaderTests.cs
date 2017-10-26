using System.IO;
using Xunit;

namespace ImageShareTemplate.Tests
{
    public class GoogleFontDownloaderTests
    {
        [Fact]
        public void CanDownloadFont()
        {
            var sut = new GoogleFontDownloader();

            var font = "Inconsolata";

            var fontPath = sut.DownloadFontToTempFolder(font);

            try
            {
                Assert.True(File.Exists(fontPath));
            }
            finally
            {
                File.Delete(fontPath);
            }
        }
    }
}