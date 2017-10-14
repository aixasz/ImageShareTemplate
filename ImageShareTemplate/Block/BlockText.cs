using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;

namespace ImageShareTemplate
{
    public class BlockText : Block, IBlockText
    {
        public string Text { get; }

        public BlockText(string text)
        {
            Text = text;
        }
    }
}
