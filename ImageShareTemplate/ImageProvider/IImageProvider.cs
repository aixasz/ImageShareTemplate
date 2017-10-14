using System;
using System.Collections.Generic;
using System.Text;

namespace ImageShareTemplate.ImageProvider
{
    public interface IImageProvider
    {
        int X { get; }
        int Y { get; }
    }
}
