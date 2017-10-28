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

            var x = width * Convert.ToSingle(options.RatioX);
            var y = height * Convert.ToSingle(options.RatioY);

            var blockPoints = new[]
            {
                (options.Block1, new ImageDimension(0, 0, x, y)),
                (options.Block2, new ImageDimension(x, 0, width, y)),
                (options.Block3, new ImageDimension(0, y, x, height)),
                (options.Block4, new ImageDimension(x, y, width, height))
            };

            Array.ForEach(blockPoints, _ =>
            {
                var block = GetBlock(_);

                if (block != null)
                {
                    var dimension = _.Item2;
                    var startX = dimension.StartX + block.PointX;
                    var startY = dimension.StartY + block.PointY;

                    switch (block)
                    {
                        case BlockText blockText:
                            var font = options.FontProvider.GetFont(options.FontFamily,options.FontSize);
                            var pointF = new PointF(startX, startY);
                            source.DrawText(blockText.Text, font, Rgba32.White, pointF, new TextGraphicsOptions(true)
                            {
                                //total available text area is width of box minus start of text
                                WrapTextWidth = dimension.EndX - dimension.StartX - blockText.PointX,
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

        private static float GetPointX((IBlock, ImageDimension) _)
        {
            return Convert.ToSingle(_.Item2.StartX);
        }

        private static float GetPointY((IBlock, ImageDimension) _)
        {
            return Convert.ToSingle(_.Item2.StartY);
        }

        private static IBlock GetBlock((IBlock, ImageDimension) _)
        {
            return _.Item1;
        }
    }
    class ImageDimension
    {
        public ImageDimension(float startY, float startX, float endX, float endY)
        {
            StartX = startY;
            StartY = startX;
            EndX = endX;
            EndY = endY;
        }

        public float StartX { get; }
        public float StartY { get; }
        public float EndX { get; }
        public float EndY { get; }
    }
}
