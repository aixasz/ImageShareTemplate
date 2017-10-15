namespace ImageShareTemplate.ImageProvider
{
    public class FacebookImageProvider : IImageProvider
    {
        public ImageSize Size { get; }

        public FacebookImageProvider(ImageSize size)
        {
            Size = size;
        }

        public int Width => Size == ImageSize.Large ? 1200 : 600;
        public int Height => Size == ImageSize.Large ? 650 : 315;
    }
}
