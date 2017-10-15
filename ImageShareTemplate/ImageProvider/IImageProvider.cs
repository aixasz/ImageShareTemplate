using System;
using System.Collections.Generic;
using System.Text;

namespace ImageShareTemplate.ImageProvider
{
    public interface IImageProvider
    {
        ImageSize Size { get; }
        int Width { get; }
        int Height { get; }
    }
}
