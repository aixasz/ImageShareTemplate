using System;
using System.Collections.Generic;
using System.Text;

namespace ImageShareTemplate
{
    public interface IBlockText : IBlock
    {
        void SetText(string text);
    }
}
