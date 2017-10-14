using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SixLabors.ImageSharp;

namespace ImageShareTemplate
{
    public class BlockImage : IBlockImage
    {
        public Rgba32 BackgroundColor { get; set; }

        public byte[] ImageData { get; set; }

        public void LoadImage(string src, SourceType sourceType)
        {
            
        }
    }
}
