using System;
using System.Collections.Generic;
using System.Text;

namespace ImageShareTemplate.ImageProvider
{
    public class FacebookImageProvider : IImageProvider
    {
        public ImageSize Size { get; set; }
        public int X => Size == ImageSize.Large ? 1200 : 600;
        public int Y => Size == ImageSize.Large ? 650 : 315;
    }
}
