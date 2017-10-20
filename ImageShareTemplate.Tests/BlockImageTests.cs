using FluentAssertions;
using Xunit;

namespace ImageShareTemplate.Tests
{
    internal class MockResourceLoader : IResourceLoader
    {
        public byte[] Data { get; set; }

        public byte[] Load(string src)
        {
            return Data;
        }
    }    

    public class BlockImageTests
    {
        [Fact]
        public void CanCreateImageBlock()
        {
            var data = new byte[] {0x0, 0x1, 0x5};

            var loader = new MockResourceLoader {Data = data};

            var sut = new BlockImage("fakeSource.jpg", loader);

            sut.Data.Should().BeSameAs(data);
        }
    }
}