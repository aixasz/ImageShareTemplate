using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;

namespace ImageShareTemplate.Block
{
    public class BlockText : IBlockText
    {
        public string Text { get; }

        public BlockText(string text)
        {
            Text = text;
        }

        public Rgba32 BackgroundColor { set; get; } = Rgba32.Transparent;

    }
}
