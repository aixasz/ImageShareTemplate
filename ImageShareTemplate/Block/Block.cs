using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;

namespace ImageShareTemplate
{
    public abstract class Block : IBlock
    {
        public Rgba32 BackgroundColor { get; set; } = Rgba32.Transparent;
    }
}
