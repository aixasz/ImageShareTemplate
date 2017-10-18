using System;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.Primitives;
using System.IO;

namespace ImageShareTemplate
{
    public static class ShareTemplate
    {
        public static string CreateAsBase64String(ShareOption options)
        {
            using (var inputStream = new MemoryStream(options.ImageSource))
            using (var image = Image.Load(inputStream))
            {
                image.Mutate(_ => _
                    .Resize(options)
                    .DrawBlocks(options)
                );

                return image.ToBase64String(ImageFormats.Jpeg);
            }
        }

        /// <summary>
        /// Resize an image to provider suggestion size.
        /// </summary>
        /// <param name="source">Source image</param>
        /// <param name="options">Image share options</param>
        /// <returns></returns>
        public static IImageProcessingContext<Rgba32> Resize(this IImageProcessingContext<Rgba32> source, ShareOption options)
        {
            return source.Resize(options.ImageProvider.Width, options.ImageProvider.Height);
        }

        /// <summary>
        /// Draw each blocks into source image.
        /// </summary>
        /// <param name="source">Source image</param>
        /// <param name="options">Image share options</param>
        /// <returns></returns>
        private static IImageProcessingContext<Rgba32> DrawBlocks(this IImageProcessingContext<Rgba32> source, ShareOption options)
        {
            var height = options.ImageProvider.Height;
            var width = options.ImageProvider.Width;

            var x = width * options.RatioX;
            var y = height * options.RatioY;

            var blockPoints = new[]
            {
                (options.Block1, (0d, 0d)),
                (options.Block2, (x, 0d)),
                (options.Block3, (0d, y)),
                (options.Block4, (x, y))
            };

            Array.ForEach(blockPoints, _ =>
            {
                var block = GetBlock(_);

                if (block != null)
                {
                    var pointX = GetPointX(_);
                    var pointY = GetPointY(_);

                    var startX = pointX + block.PointX;
                    var startY = pointY + block.PointY;

                    switch (block)
                    {
                        case BlockText blockText:
                            var font = SystemFonts.CreateFont("Tahoma", 56, FontStyle.Regular);
                            var pointF = new PointF(startX, startY);
                            source.DrawText(blockText.Text, font, Rgba32.White, pointF, new TextGraphicsOptions(true)
                            {
                                HorizontalAlignment = HorizontalAlignment.Left,
                                VerticalAlignment = VerticalAlignment.Top
                            });
                            break;
                        case BlockImage blockImage:
                            var point = new Point(Convert.ToInt32(startX), Convert.ToInt32(startY));
                            source.DrawImage(Image.Load(blockImage.Data), default(Size), point, GraphicsOptions.Default);
                            break;
                        default:
                            break;
                    }
                }
            });
            return source;
        }

        private static float GetPointX((IBlock, (double, double)) _)
        {
            return Convert.ToSingle(_.Item2.Item1);
        }

        private static float GetPointY((IBlock, (double, double)) _)
        {
            return Convert.ToSingle(_.Item2.Item2);
        }

        private static IBlock GetBlock((IBlock, (double, double)) _)
        {
            return _.Item1;
        }
    }
}
