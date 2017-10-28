using ImageShareTemplate.ImageProvider;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ImageShareTemplate.Tests.IntegrationTests
{
    public class TextWrappingTests : ImageRenderTests
    {
        private readonly ShareOption options;

        public TextWrappingTests()
        {
            options = new ShareOption
            {
                ImageProvider = new FacebookImageProvider(ImageSize.Small),
                RatioX = 0.6,
                RatioY = 0.6,
                ImageSource = MinimalBitmap,
                FontFamily = "Tahoma",
                FontSize = 24
            };
        }

        [Fact]
        public void TextInBlock1Wraps()
        {
            options.Block1 = new BlockText("Test the first line Test the second line Test the third line...")
            {
                PointX = 20,
                PointY = 20
            };

            byte[] result = CreateImageFromOptions(options);

            AssertImage(result);
        }

        [Fact]
        public void TextInBlock2Wraps()
        {
            options.Block2 = new BlockText("Test the first line Test the second line Test the third line...")
            {
                PointX = 20,
                PointY = 20
            };

            byte[] result = CreateImageFromOptions(options);

            AssertImage(result);
        }

        [Fact]
        public void TextInBlock3Wraps()
        {
            options.Block3 = new BlockText("Test the first line Test the second line Test the third line...")
            {
                PointX = 20,
                PointY = 20
            };

            byte[] result = CreateImageFromOptions(options);

            AssertImage(result);
        }

        [Fact]
        public void TextInBlock4Wraps()
        {
            options.Block4 = new BlockText("Test the first line Test the second line Test the third line...")
            {
                PointX = 20,
                PointY = 20
            };

            byte[] result = CreateImageFromOptions(options);

            AssertImage(result);
        }
    }
}
