using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageShareTemplate
{
    public interface IBlockImage : IBlock
    {
        byte[] Data { get; }
    }
}
