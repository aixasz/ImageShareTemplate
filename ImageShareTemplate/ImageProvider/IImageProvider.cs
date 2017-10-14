using System;
using System.Collections.Generic;
using System.Text;

namespace ImageShareTemplate.ImageProvider
{
    public interface IImageProvider
    {
        ImageSize Size { get; set; }
        int X { get; }
        int Y { get; }
    }
}
