using System.IO;
using FluentAssertions;
using Xunit;

namespace ImageShareTemplate.Tests
{
    public class BasicResourceLoaderTests
    {
        [Fact]
        public void CanLoadResourceFromFile()
        {
            var sut = new BasicResourceLoader();

            var filePath = "testFile.jpg";

            var data = new byte[] { 0x0, 0x1, 0x5 };

            File.WriteAllBytes(filePath, data);

            var loadedData = sut.Load(filePath);

            try
            {
                loadedData.Should().BeEquivalentTo(data);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [Fact]
        public void CanLoadResourceFromHttp()
        {
            var sut = new BasicResourceLoader();

            var data = sut.Load("http://httpbin.org/");

            data.Should().NotBeNull();
            data.Length.Should().BeGreaterThan(0);
        }

        [Fact]
        public void CanLoadResourceFromHttps()
        {
            var sut = new BasicResourceLoader();

            var data = sut.Load("https://httpbin.org/");

            data.Should().NotBeNull();
            data.Length.Should().BeGreaterThan(0);
        }

        [Fact]
        public void CanDetermineResourceType()
        {
            var sut = new BasicResourceLoader();

            sut.GetSourceType("http://httpbin.org/").Should().Be(SourceType.Url);
            sut.GetSourceType("https://httpbin.org/").Should().Be(SourceType.Url);
            sut.GetSourceType("fakeImage.png").Should().Be(SourceType.Path);
            sut.GetSourceType("file://fakeImage.png").Should().Be(SourceType.Path);
        }
    }
}