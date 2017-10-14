using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageShareTemplate
{
    public interface IBlock
    {
        Rgba32 BackgroundColor { get; set; }
    }
}
