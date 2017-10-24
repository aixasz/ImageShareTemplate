using ImageShareTemplate.ImageProvider;
using SixLabors.ImageSharp;
using System;

namespace ImageShareTemplate.Experiment
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = FileHelpers.LoadImageFormPath("main-image.jpeg");

            var textBlockItem = new BlockText("Test the first line\r\nTest the second line\r\nTest the third line...")
            {
                PointX = 100,
                PointY = 100
            };

            var imageBlockItem = new BlockImage("imagesharp-logo-256.png")
            {
                PointX = 100,
                PointY = 10
            };

            var options = new ShareOption
            {
                ImageProvider = new FacebookImageProvider(ImageSize.Large),
                Block1 = textBlockItem,
                Block3 = imageBlockItem,
                RatioX = 0.6, // 60%
                RatioY = 0.6, // 60%
                ImageSource = bytes,
                FontFamily = "Tahoma",
                FontSize = 56
            };

            var result = Convert.FromBase64String(
                ShareTemplate.CreateAsBase64String(options).Split(',')[1]
            );

            using (var image = Image.Load(result))
            {
                image.Save("output.jpeg");
            }

            options.FontProvider = new GoogleFontDownloader();
            options.FontFamily = "Inconsolata";

            result = Convert.FromBase64String(
                ShareTemplate.CreateAsBase64String(options).Split(',')[1]
            );

            using (var image = Image.Load(result))
            {
                image.Save("output2.jpeg");
            }
        }
    }
}
