using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.ImageSharp;

namespace ImageShareTemplate.Block
{
    public class BlockText : IBlockText
    {
        private string _text;

        public Rgba32 BackgroundColor { set; get; }

        public void SetText(string text)
        {
            _text = text;
        }
    }
}
