using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageShareTemplate
{
    public interface IBlockImage : IBlock
    {
        void LoadImage(string src, SourceType sourceType);
    }
}
